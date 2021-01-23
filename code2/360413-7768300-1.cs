    public class MyModel
    {
        public string Account { get; set; }
        public string Page { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var json = "{account:\"123\", page:\"item\"}";
            var serializer = new JavaScriptSerializer();
            var model = serializer.Deserialize<MyModel>(json);
            Console.WriteLine("account = {0}, page = {1}", model.Account, model.Page);
        }
    }
