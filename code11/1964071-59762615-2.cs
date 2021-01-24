    public class Person : INotifyPropertyChanged
    {
        private string _name;
        public string Name 
        { 
           get => _name; 
           set
           {
               _name = value;
               if (PropertyChanged != null)
                   PropertyChanged(this, nameof(Name)); 
           }
        }
        
        public event PropertyChangedHandler PropertyChanged;
    }
