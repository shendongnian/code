    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            listview.ItemsSource = AddPandaFamily();
        }
        List<string> pandaFamily = new List<string>();
        public List<string> AddPandaFamily()
        {
            for (int i = 0; i < 50; i++)
            {
                pandaFamily.Add("Smiley Panda");
                pandaFamily.Add("Red Panda");
                pandaFamily.Add("Qinling Panda");
                pandaFamily.Add("Oleosa Panda");
                pandaFamily.Add("Ailuropoda Panda");
            }
            return pandaFamily;
        }
    }
