    using Newtonsoft.Json;
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            testAsync();
        }
        public async Task testAsync() {
            string json = @"{
                  'id': '123',
                  'name': 'User name',
                  'nik': '213123'
                }";
            Model m = JsonConvert.DeserializeObject<Model>(json);
            Console.WriteLine(m.name);
            Console.WriteLine(m.nik);
        }
    }
    public class Model
    {
        public string id { get; set; }
        public string name { get; set; }
        public string nik { get; set; }
        public string Created { get; set; }
    }
