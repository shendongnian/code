public class Category
    {
        public bool status { get; set; }
        public object message { get; set; }
        public IList<Datum> data { get; set; } 
    }
    public class SubCat
    {
        public int menu_id { get; set; }
        public string menu_title { get; set; }
        public int menu_parent { get; set; }
        public string menu_sort { get; set; }
        public int courses_count { get; set; }
        public string menu_status { get; set; }
        public IList<object> subCat { get; set; }
    }
    public class Datum
    {
        public int menu_id { get; set; }
        public string menu_title { get; set; }
        public int menu_parent { get; set; }
        public string menu_sort { get; set; }
        public string menu_status { get; set; }
        public int courses_count { get; set; }
        public IList<SubCat> subCat { get; set; }
    }
}
The API Call Request
async Task CallApi()
        {
            string Url = "your Link Goes Here";
            HttpResponseMessage response;
            string return_value = "empty";
            try
            {
                HttpClient _client = new HttpClient();
                response = await _client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    return_value = await response.Content.ReadAsStringAsync();
                    var categs = JsonConvert.DeserializeObject<Category>(return_value).data;
                    CategList.ItemsSource = categs;
                }
                else
                {
                    return_value = "not successful";
                }
            }
            catch (Exception ex)
            {
                return_value = (string)ex.Message + " :: " + ex.InnerException.Message;
            }
        }
