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
        public NotifyObservableCollection<ParameterBase> Parameters {
            get { return _parameters; }
            set {
                NotifyCollectionChangedEventHandler cceh = (sender, args) => OnPropertyChanged();
                if (_parameters != null) _parameters.CollectionChanged -= cceh;
                _parameters = value;
                //needed for Binding to AItem at xaml directly
                _parameters.CollectionChanged += cceh; 
            }
        }
        public NotifyObservableCollection<ParameterBase> DefaultParameters {
            get { return _defaultParameters; }
            set {
                NotifyCollectionChangedEventHandler cceh = (sender, args) => OnPropertyChanged();
                if (_defaultParameters != null) _defaultParameters.CollectionChanged -= cceh;
                _defaultParameters = value;
                //needed for Binding to AItem at xaml directly
                _defaultParameters.CollectionChanged += cceh;
            }
        }
    
    public class MyViewModel {
        public NotifyObservableCollection<AItem> DataItems { get; set; }
    }
