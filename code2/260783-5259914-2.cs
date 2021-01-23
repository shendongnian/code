    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            var items = new List<ItemViewModel>()
            {
                new ItemViewModel{Id = 1, Title="First", IsImage = true},
                new ItemViewModel{Id = 2, Title="Second", IsImage = false},
                new ItemViewModel{Id = 3, Title="Third", IsImage = false}
            };
            this.DataContext = new MainViewModel { Items = items };
        }
    }
    public class MainViewModel
    {
        public List<ItemViewModel> Items { get; set; }
    }
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsImage { get; set; }
        public Visibility IsImageTemplate
        {
            get { return (IsImage == true) ? Visibility.Visible : Visibility.Collapsed; }
        }
        public Visibility IsTextBoxTemplate
        {
            get { return IsImage == false ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
