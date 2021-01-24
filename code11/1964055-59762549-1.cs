        public partial class MainPage : ContentPage
    {
        MyViewModel myViewModel;
        public MainPage()
        {
            InitializeComponent();
             myViewModel=  new MyViewModel();
            BindingContext = myViewModel;
        }
        private void PickerCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            myViewModel.CidadeSelectedIndex = selectedIndex;
        }
    }
