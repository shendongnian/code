    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    namespace WpfApplication2
    {
    public class ViewModel : INotifyPropertyChanged
    {
        private BindingList<Model> _modelList;
        public BindingList<Model> ModelList
        {
            get { return _modelList; }
            set { _modelList = value;
                   NotifyPropertyChanged("ModelList");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
    }
