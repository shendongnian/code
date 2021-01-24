    public partial class Page1 : ContentPage
    {
       
        public static Dictionary<string, bool> keyValuePairs = new Dictionary<string, bool>();
        public Page1()
        {
            InitializeComponent();
            keyValuePairs.Add("Create", true);
            SWitch.BindingContext = new SwitchModel(); 
        }
