    public class Person : INotifyPropertyChanged
        {​
            public event PropertyChangedEventHandler PropertyChanged = delegate { };​
            public String name ...;​
            public String age ...;​
            private bool isShow = false;​
            public bool IsShow​
            {​
                get { return isShow; }​
                set​
                {​
                    isShow = value;​
                    this.OnPropertyChanged();​
                }​
            }​
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)​
            {​
                // Raise the PropertyChanged event, passing the name of the property whose value has changed.​
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));​
            }​
        }
