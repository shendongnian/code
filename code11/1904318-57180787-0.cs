    public class FileWrapper : INotifyPropertyChanged
    {
        private FileInfo _file;
        private bool _selected; 
    
        public FileWrapper(FileInfo file) 
        { 
            File = file; 
            Selected = false; 
        } 
    
        public FileInfo File 
        { 
            get { return _file; }
            set
            {
                _file = value;
                OnPropertyChanged("File")
            }
        } 
    
        public bool Selected 
        { 
            get { return _selected ; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected")
            }
        } 
    
        public event PropertyChangedEventHandler PropertyChanged;  
        private void OnPropertyChanged(string propertyname) 
        {  
            if (PropertyChanged != null) 
            {  
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));  
            }  
        }  
    }
