    public class BaseViewModel : MvxViewModel
    {
        public BaseViewModel()
        {
        }
        public string this[string index] => AppResources.ResourceManager.GetString(index);
    }
    
