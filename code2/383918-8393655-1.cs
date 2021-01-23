    public class PictogramViewModel : ViewModelBase
    {
        private string _imageSourcePath;
        public string ImageSourcePath
        {
            get { return _imageSourcePath; }
            set
            {
                _imageSourcePath = value;
                RaiseOnPropertyChanged("ImageSourcePath");
            }
        }
    
        private string _toolTipText;
        public string ToolTipText
        {
            get { return _toolTipText; }
            set
            {
                _toolTipText = value;
                RaiseOnPropertyChanged("ToolTipText");
            }
        }
    }
