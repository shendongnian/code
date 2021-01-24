    public class StructureDesignViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
         string selectedComponentStructure;
         public string SelectedComponentStructure
         {
            get
            {
                return selectedComponentStructure;
            }
            set
            {
                selectedComponentStructure = value;
                SetPropertyValue(ref selectedComponentStructure, value);
            }
            
         }
        protected void OnPropertyChanges([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetPropertyValue<T>(ref T bakingFiled, T value, [CallerMemberName] string proertyName = null)
        {
            bakingFiled = value;
            OnPropertyChanges(proertyName);
        }
    }
