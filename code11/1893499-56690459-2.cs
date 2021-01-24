    public class ViewModel : INotifyPropertyChanged
    {
        public TestViewModel()
        {
          this.ImageSources = new ObservableCollection<string>() { @"Resources\Icons\image.png" };      
        }
    
        /// <summary>
        /// Event fired whenever a child property changes its value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
        /// <summary>
        /// Method called to fire a <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName"> The property name. </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private ObservableCollection<string> imageSources;   
        public ObservableCollection<string> ImageSources
        {
          get => this.imageSources;
          set 
          { 
            this.imageSources = value; 
            OnPropertyChanged();
          }
        }
    }
