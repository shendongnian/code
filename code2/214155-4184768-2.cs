    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel;
    
    namespace SDKSample
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            public string ViewName
            {
                get { return viewName; }
                set
                {
                    if (viewName == value)
                        return;
    
                    viewName = value;
                    NotifyPropertyChanged("ViewName");
                }
            }
            private string viewName;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            void NotifyPropertyChanged(string name)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
