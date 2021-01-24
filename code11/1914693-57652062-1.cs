    [ContentProperty(Name = "ItemTemplate")]
    public class NavigationItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item)
        {
            return ItemTemplate;
        }
            
    }
    ​
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
    
            NavigationList = new ObservableCollection<ViewModel>();
            NavigationList.Add(new ViewModel { Name = "item1", IsEnabled = false });
            NavigationList.Add(new ViewModel { Name = "item2", IsEnabled = false });
            NavigationList.Add(new ViewModel { Name = "item3", IsEnabled = false });
            NavigationList.Add(new ViewModel { Name = "item4", IsEnabled = false });
                
        }
        private ObservableCollection<ViewModel> NavigationList { get; set; }
    }
