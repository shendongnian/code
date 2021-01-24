public abstract class Entity<T>
    {
        [Browsable(false)]
        public string AddedItem { get; set; }
        public virtual async Task<bool> Add()
        {
            using (var client = new HttpClient())
            {
                string url = Secrets.ApiAddress + $"Create{typeof(T).Name}?token=" + Secrets.TenantToken + "&UserId=" + RuntimeSettings.UserId;
                var serializedProduct = JsonConvert.SerializeObject(this);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(new Uri(url), content);
                if (result.IsSuccessStatusCode)
                {
                    var rString = await result.Content.ReadAsStringAsync();
                    AddedItem = rString;
                    return true;
                }
                else
                {
                    MessageBox.Show("Serwer zwrócił błąd przy próbie utworzenia rekordu. Wiadomość: " + result.ReasonPhrase);
                    return false;
                }
            }
        }
    }
And deriving class was changed to:
public class Car : Entity<Car>
    {
        public async override Task<bool> Add()
        {
            bool x = await base.Add();
            if (x)
            {
                try
                {
                    Car _this = JsonConvert.DeserializeObject<Car>(AddedItem);
                    this.CarId = _this.CarId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Tworzenie nowego rekordu zakończone powodzeniem!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
I found HimBromBeere's answer most helpful and so chose his post as answering my question.
