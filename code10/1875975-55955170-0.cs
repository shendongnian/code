    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange(string prop)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool _IsUpdated = false;
        public virtual bool IsUpdated
        {
            get
            {
                return _IsUpdated;
            }
            set
            {
                _IsUpdated = value;
                RaisePropertyChange("IsUpdated");
            }
        }
    }
