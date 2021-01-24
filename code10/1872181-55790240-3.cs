    public class HostViewModel : INotifyPropertyChanged
    {
        private string nextButtonText;
    
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
        public HostViewModel()
        {
            this.NextButtonText = "Next";
        }
    
        public string NextButtonText
        {
            get { return this.nextButtonText; }
            set
            {
                this.nextButtonText = value;
                this.OnPropertyChanged();
            }
        }
    
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
     
