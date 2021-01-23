    public class MyViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<Card> comboData;
            
            public event PropertyChangedEventHandler PropertyChanged;
    
            public ObservableCollection<Card> ComboData
            {
                get
                {
                    return this.comboData;
                }
    
                set
                {
                    if (this.comboData != value)
                    {
                        this.comboData = value;
                        this.NotifyPropertyChanged("ComboData");
                    }
                }
            }
    
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
        }
