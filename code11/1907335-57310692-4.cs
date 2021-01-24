    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            bool IsMeet = true ;
            if (IsMeet)
            {
                Navigation.PushModalAsync(new MasterDetailPage1());
            }
            else
            {
                var btn = new Button();
                btn.CommandParameter = new MasterDetailPage1();
                btn.Command = new Command<MasterDetailPage1>((key) =>
                {
                    // Navigation.PushAsync(key);
                    Navigation.PushModalAsync(key);
                });
                //  btn.Clicked += Btn_Clicked;
                Content = btn;
            }
            
        }
