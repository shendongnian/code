        public partial class MainPage : ContentPage
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public MainPage()
        {
            InitializeComponent();
            employees.Add(new Employee { Name = "Rob Finnerty", Description = "Rob FinnertyRob FinnertyRob FinnertyRob FinnertyRob FinnertyRob FinnertyRob FinnertyRob FinnertyRob Finnerty" });
            employees.Add(new Employee { Name = "Bill Wrestler", Description = "Bill WrestlerBill Wrestler" });
            employees.Add(new Employee { Name = "Dr. Geri-Beth Hooper", Description = "Dr. Geri-Beth Hooper" });
            employees.Add(new Employee { Name = "Dr. Keith Joyce-Purdy", Description = "Dr. Keith Joyce-PurdyDr. Keith Joyce-PurdyDr. Keith Joyce-Purdy" });
            employees.Add(new Employee { Name = "Sheri Spruce", Description = "Sheri SpruceSheri Spruce" });
            employees.Add(new Employee { Name = "Burt Indybrick", Description = "Burt IndybrickBurt Indybrick" });
            lv_List.ItemsSource = employees;
        }
    }
