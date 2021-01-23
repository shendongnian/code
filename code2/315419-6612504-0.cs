    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    
    namespace Foo
    {
      public class FooViewModel : INotifyPropertyChanged
      {
        public FooViewModel()
        {
          IsCheckedState = true;
          ChangeStateCommand = new MyCmd(ChangeState);
          MultiChangeStateCommand = new MyCmd(MultiChangeState);
        }
    
        public bool? IsCheckedState { get; private set; }
        public ICommand ChangeStateCommand { get; private set; }
        public ICommand MultiChangeStateCommand { get; private set; }
    
        private void ChangeState()
        {
          switch (IsCheckedState)
          {
            case null:
              IsCheckedState = true;
              break;
            default:
              IsCheckedState = null;
              break;
          }
    
          OnPropertyChanged("IsCheckedState");
        }
    
        private void MultiChangeState()
        {
          ChangeState();
          ChangeState();
          ChangeState();
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
