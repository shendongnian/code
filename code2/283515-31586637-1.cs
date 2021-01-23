    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion
    }
    public class ExampleViewModel : ViewModelBase 
    {
        /// <summary>
        /// Property bound to textbox in xaml.
        /// </summary>
        public String TextInViewModel
        {
            get { return _textInViewModel; }
            set
            {
                _textInViewModel= value;
                RaisePropertyChanged("TextInViewModel");
            }
        }
        private string _textInViewModel;
        /// <summary>
        /// Constructor.
        /// </summary>
        public ExampleViewModel()
        {
			
        }
    }
