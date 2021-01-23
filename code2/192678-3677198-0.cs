    public class CustomClass : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
            private void OnPropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
            private string mProp;
            public string Prop
            {
                get
                {
                    return mProp;
                }
                set
                {
                    if (value != mProp)
                    {
                        mProp = value;
                        OnPropertyChanged("Prop");
                    }
                }
            }
        }
