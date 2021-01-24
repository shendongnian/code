    public class Translator : INotifyPropertyChanged
    {
        public string this[string text]
        {
        get
        {
            return Strings.ResourceManager.GetString(text, Strings.Culture);
        }
        }        
    
        public static Translator Instance { get; } = new Translator();
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
