    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            string jsonStr = "[{'Nazwa': 'Czekolada mleczna Sport & Fitness','Opis': 'Przykładowy opis produktu Czekolada mleczna Sport & Fitness', 'Zdjecie': 'https://interactive-examples.mdn.mozilla.net/media/examples/grapefruit-slice-332-332.jpg'}]";
            var ObjContactList = JsonConvert.DeserializeObject<List<RootObject>>(jsonStr);
            RootObject obj = ObjContactList[0];
            foto.Source = obj.Zdjecie;
        }
    }
    public class RootObject
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Zdjecie { get; set; }
    }
