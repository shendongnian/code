    public interface IActivity<T>
    {
        Task<T> Result { get; }
    }
    
    public class RegistrationActivity : IActivity<Person>
    {
        private TaskCompletionSource _tcs;
        public Task<Person> Result => _tcs.Task;
    
        public string Name {get;set;}
    
        public ICommand Ok => new RelayCommand(() => _tcs.SetResult(new Person(Name)));
        public ICommand Cancel => new RelayCommand(() => _tcs.SetCancelled());
    
    }
    
    public class RegistrationWindow : Window
    {
        public RegistrationWindow(RegistrationActivity viewModel)
        {
            InitializeComponents();
            DataContext = viewModel;
            viewModel.Task.ContinueWith(() => Close());
        }   
    }
    builder.Register<RegistrationWindow>();
