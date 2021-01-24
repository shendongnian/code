    using System.ComponentModel;
    namespace WpfApp1
    {
        public class ViewModelBase<T> : INotifyPropertyChanged
        {
            T model;
            public T Model { get { return model; } }
            public ViewModelBase(T model)
            {
                this.model = model;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null && !string.IsNullOrEmpty(propertyName))
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
