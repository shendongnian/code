    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    namespace SOF
    {
        public class RelayCommand : ICommand
        {
            Action<object> MethodToExecute;
            Func<object, bool> FunctionToCheck;
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
            public bool CanExecute(object parameter)
            {
                if (FunctionToCheck == null) return true;
                return FunctionToCheck.Invoke(parameter);
            }
            public void Execute(object parameter)
            {
                MethodToExecute.Invoke(parameter);
            }
            public RelayCommand(Action<object> ActualMethodToExecute, Func<object, bool> ActualFunctionToCheck)
            {
                MethodToExecute = ActualMethodToExecute;
                FunctionToCheck = ActualFunctionToCheck;
            }
            public RelayCommand(Action<object> ActualMethodToExecute)
            {
                new RelayCommand(ActualMethodToExecute, null);
            }
        }
        public abstract class ObservableModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string propname = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
            }
            public ObservableModel() { }
        }
    }
