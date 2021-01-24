    using Newtonsoft.Json;
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Name = name.Text;
            person.Favourite = fav.Text;
            person.Desc = desc.Text;
            string json = JsonConvert.SerializeObject(person, Formatting.Indented);
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Favourite { get; set; }
        public string Desc { get; set; }
    }
