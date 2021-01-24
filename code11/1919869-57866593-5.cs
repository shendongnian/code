     public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var categories = new ObservableCollection<CategoryModel>() {
                new CategoryModel{CategoryName="A",values= {new ValueModel{ ValueName="1" }, new ValueModel { ValueName = "2" }, new ValueModel { ValueName = "3" } ,new ValueModel{ ValueName="4"}} },
                 new CategoryModel{CategoryName="B",values= {new ValueModel{ ValueName="5" }, new ValueModel { ValueName = "6" }, new ValueModel { ValueName = "7" } } }
            };
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = categories;
            BindingContext = categoryViewModel;
        }
        private void DiameterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryViewModel viewModel = BindingContext as CategoryViewModel;
            ValuePicker.ItemsSource = viewModel.Categories[((Picker)sender).SelectedIndex].values;
        }
    }
