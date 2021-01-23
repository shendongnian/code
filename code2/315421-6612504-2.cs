    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    
    namespace Foo
    {
      public class FooViewModel : INotifyPropertyChanged
      {
        private bool? _isCheckedState = true;
    
        public FooViewModel()
        {
          ChangeStateCommand = new MyCmd(ChangeState);
        }
    
        public bool? IsCheckedState
        {
          get { return _isCheckedState; }
        }
    
        public ICommand ChangeStateCommand { get; private set; }
    
        private void ChangeState()
        {
          switch (_isCheckedState)
          {
            case null:
              _isCheckedState = true;
              break;
            default:
              _isCheckedState = null;
              break;
          }
    
          OnPropertyChanged("IsCheckedState");
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
          var changed = PropertyChanged;
          if (changed != null)
            changed(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    
      public class MyCmd : ICommand
      {
        private readonly Action _execute;
        public event EventHandler CanExecuteChanged;
    
        public MyCmd(Action execute)
        {
          _execute = execute;
        }
    
        public void Execute(object parameter)
        {
          _execute();
        }
    
        public bool CanExecute(object parameter)
        {
          return true;
        }
      }
    }
