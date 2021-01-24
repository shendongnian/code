    public partial class CategoriesMenuDetail : ContentPage
    {
        public CategoriesMenuDetailViewModel ViewModel { get; set; }
    
        public CategoriesMenuDetail()
        {
            ViewModel = new CategoriesMenuDetailViewModel();
    
            InitializeComponent();
    
            BindingContext = Viewmodel;
            
        }
    }
    
    
    public class CategoriesMenuDetailViewModel 
    {
        public List<CategoryDetail>MyCategories { get; set; } // if you don't add new items not need observable collection
    
        public ICommand ButtonClickedCommand => new Command((cParameter)=> ButtonclickedCommandExecute((CategoryDetail)cParameter)
    
    
        private void ButtonclickedCommandExecute(CategoryDetail myParam)
        {
            //Here goes you image's logic
            if (myParam.Name == "Carnes")
                myParam.ImageName = Image.FromFile("");
        }
    
    }
    
    public class CategoryDetail : ObservableObject
    {
        public int Id { get; set; }
        private string _name;
        public string Name { get =>_name; set=>SetProperty(ref _name, value); }
    
        private string _imageName;
        public string  ImageName { get=>_imageName; set=>SetProperty(ref _imageName, value); }
    }
    
    
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
    
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    
        }
