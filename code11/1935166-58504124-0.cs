    public class ViewModelItem : INotifyPropertyChanged
    {
        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                // fire PropertyChanged event
                // add call optional additional code here
            }
        }
    }
