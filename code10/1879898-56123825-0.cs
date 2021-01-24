    public class ActivityTable : INotifyPropertyChanged
    {
        string activityDescription;
        public string ActivityDescription
        {
            get => activityDescription;
            set
            {
                if (activityDescription != value)
                {
                    activityDescription = value;
                    onPropertyChanged();
                }
            }
        }
    
        bool selected;
        public bool Selected
        {
            get => selected;
            set
            {
                if (selected != value)
                {
                    selected = value;
                    onPropertyChanged();
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
