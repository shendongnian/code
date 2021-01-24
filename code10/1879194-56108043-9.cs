       public partial class MainPage : ContentPage
    {
        Firebasehelper firebaseHelper;
        public MainPage()
        {
            InitializeComponent();
            firebaseHelper = new Firebasehelper();
            BtnAdd.Clicked += BtnAdd_Clicked;
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            // AddUser(int userid, string first_name, string last_name, string password)
            await firebaseHelper.AddUser(Convert.ToInt32(1), "Jon","hard","123.com");
            await firebaseHelper.AddUser(Convert.ToInt32(1), "Leon", "esay", "1234.com");
            await firebaseHelper.AddUser(Convert.ToInt32(1), "Rebecca", "middlue", "12345.com");
            await DisplayAlert("Success", "Person Added Successfully", "OK");
           var allPersons = await firebaseHelper.GetAllUsers();
           lstPersons.ItemsSource = allPersons;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                base.OnAppearing();
                var allUsers = await firebaseHelper.GetAllUsers();
                lstPersons.ItemsSource = allUsers;
            }
            catch (Exception ex)
            {
                throw new Exception("OnAppearing  Additional information..." + ex, ex);
            }
        }
    }
