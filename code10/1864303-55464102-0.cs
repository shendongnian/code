    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    public class Test : INotifyPropertyChanged
    {
        private string _text;
    
        public string Text
        {
            get => _text;
            set
            {
                if (value == _text)
                    return;
    
                _text = value;
                OnPropertyChanged();
            }
        }
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
