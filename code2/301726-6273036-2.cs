    public class OtherViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public OtherViewModel(string name) { this.Name = name; }
    }
    public class MyViewModel : ViewModelBase
    {
        public ObservableCollection<OtherViewModel> Items { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public MyViewModel()
        {
            this.Items = new ObservableCollection<OtherViewModel>();
            this.AddCommand = new FuncCommand<string>(
                (name) => !String.IsNullOrEmpty(name),
                (name) => this.Items.Add(new OtherViewModel(name)));
            this.RemoveCommand = new FuncCommand<OtherViewModel>(
                (vm) => vm != null,
                (vm) => this.Items.Remove(vm));
        }
    }
