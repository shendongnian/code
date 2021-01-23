    using System.Windows.Input;
    using Expander.Commands;
     
    namespace Expander.ViewModels
    {
      public class MainViewModel : ViewModelBase
      {
        public MainViewModel()
        {
          ButtonSelected = new DelegateCommand<object>(OnButtonSelected, CanButtonSelected);
        }
        
        public ICommand ButtonSelected { get; set; }
        private void OnButtonSelected(object obj)
        {
          IsButtonSelected = true;
        }
        
        private bool CanButtonSelected(object obj)
        {
          return true;
        } 
        
        private bool _isButtonSelected = true;
        public bool IsButtonSelected
        {
          get
          {
            return _isButtonSelected;
          }
          set
          {
            _isButtonSelected = value;
            OnPropertyChanged("IsButtonSelected");
          }
        }
      }
    }
