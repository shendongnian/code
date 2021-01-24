    namespace ShoppingList
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class Page1 : ContentPage
        {
            public ObservableCollection<Item> DisplayItems;
            public Page1()
            {
                InitializeComponent();
                DisplayItems = new ObservableCollection<Item>();
                DisplayItems .Add(new Item{ name="Rob Finnerty"});
                DisplayItems .Add(new Item{ name="Bill Wrestler"});
                BindingContext = this;
            }
        }
    }
