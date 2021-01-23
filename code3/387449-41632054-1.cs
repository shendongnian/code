    public abstract class ParameterBase : INotifyPropertyChanged
    {
        protected readonly CultureInfo Ci = new CultureInfo("en-US");
        private string _value;
        public string Value {
            get { return _value; }
            set {
                if (value == _value) return;
                _value = value;
                OnPropertyChanged();
            }
        }
    }
    public class AItem {
        public NotifyObservableCollection<ParameterBase> Parameters { get; set; }
        public NotifyObservableCollection<ParameterBase> DefaultParameters { get; set; }
    }
    
    public class MyViewModel {
        public NotifyObservableCollection<AItem> DataItems { get; set; }
    }
