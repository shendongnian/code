    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    
    namespace ButtonContentExample
    {
        public class RelayCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public RelayCommand(Action<object> execute) : this(execute, null) { }
            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                ExecuteAction = execute;
                CanExecutePredicate = canExecute ?? new Predicate<object>(obj => true);
            }
            public Action<object> ExecuteAction { get; }
            public Predicate<object> CanExecutePredicate { get; }
            public bool CanExecute(object parameter) => CanExecutePredicate(parameter);
            public void Execute(object parameter) => ExecuteAction(parameter);
        }
    
        public abstract class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void Notify<T>(ref T t, T value, [CallerMemberName] string name = "")
            {
                t = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public class ExampleViewModel : ViewModelBase
        {
            private string testResult;
            private ObservableCollection<TestItemViewModel> items = new ObservableCollection<TestItemViewModel>();
            public ExampleViewModel()
            {
                for (var i = 0; i < 50; i++) Items.Add(new TestItemViewModel(this) { Value = i });
            }
            public ObservableCollection<TestItemViewModel> Items
            {
                get => items;
                set => Notify(ref items, value);
            }
    
            public string TestResult
            {
                get => testResult;
                set => Notify(ref testResult, value);
            }
        }
    
        public class TestItemViewModel : ViewModelBase
        {
            private int value;
            private string result;
            public TestItemViewModel(ExampleViewModel parent)
            {
                Parent = parent;
                TestCommand = new RelayCommand(obj => Result = obj.ToString());
            }
            public int Value
            {
                get => value;
                set => Notify(ref this.value, value);
            }
    
            public string Result
            {
                get { return result; }
                set
                {
                    Notify(ref result, value);
                    Parent.TestResult = value;
                }
            }
    
            public RelayCommand TestCommand { get; }
            public ExampleViewModel Parent { get; }
        }
    }
