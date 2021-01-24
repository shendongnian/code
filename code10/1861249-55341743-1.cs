c#
public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Button invia = FindViewById<Button>(Resource.Id.submit);
            EditText utenteInserito = FindViewById<EditText>(Resource.Id.utente);
            EditText passwordInserito = FindViewById<EditText>(Resource.Id.password);
            invia.Click += async delegate
            {
                HttpClient client = new HttpClient();
                string utente = utenteInserito.Text;
                string password = passwordInserito.Text;
                string json = "{'user': '"+utente+"','password': '"+password+"'}";
                string URL = "http://192.168.1.11:57279/api/utente";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(URL, content);
                var responseString = await response.Content.ReadAsStringAsync();
            };
        }
    }
**Updated code using a defined Model**
C#
invia.Click += delegate
            {
                string user = utenteInserito.Text;
                string password = passwordInserito.Text;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.1.11:57279/api/");
                var utente = new Utente
                {
                    user = user,
                    password = password
                };
                var postTask = client.PostAsJsonAsync<Utente>("utente", utente);
                postTask.Wait();
            };
