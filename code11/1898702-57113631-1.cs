    // MainViewModel.cs
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            searchCommand = new RelayCommand(SearchExecute);
            People = new ObservableCollection<Person>();
        }
        private ObservableCollection<Person> people;
        public ObservableCollection<Person> People
        {
            get { return people; }
            protected set { Set(ref people, value); }
        }
        private string lastNameTB;
        public string LastNameTB
        {
            get { return lastNameTB; }
            set { Set(ref lastNameTB, value); }
        }
        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set { Set(ref selectedPerson, value); }
        }
        
        private RelayCommand searchCommand;
        public ICommand SearchCommand
        {
            get { return searchCommand; }
        }
        
        private void SearchExecute(object _)
        {
            DataAccess db = new DataAccess();
            var data = db.GetPeople(LastNameTB);
            var results = new ObservableCollection<Person>(data);
            People = results;
            SelectedPerson = results.FirstOrDefault();
        }
    }
    // Person.cs
    public class Person : ObservableObject
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { Set(ref firstName, value); FullInfo = null; }
        }
        
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { Set(ref lastName, value); FullInfo = null;  }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { Set(ref email, value); }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { Set(ref phoneNumber, value); FullInfo = null;  }
        }
        private string fullInfo;
        public string FullInfo
        {
            get { return fullInfo; }
            set
            {
                value = $"{FirstName} {LastName} ({PhoneNumber})";
                Set(ref fullInfo, value);
            }
        }
    }
    // MainWindow.xaml
    <Window x:Class="YourNameSpace.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:vm="clr-namespace:YourNameSpace.ViewModels"
            mc:Ignorable="d"
            Title="Search"
            Height="400" Width="600"
            MinHeight="150" MinWidth="250">
        <Window.DataContext>
            <vw:MainViewModel />
        </Window.DataContext>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <Label Grid.Row="0" Grid.Column="0">Last Name</Label>
            <TextBox Grid.Row="0" Grid.Column="1"
                     Text="{Binding LastNameTB,UpdateSourceTrigger=PropertyChanged}" />
            <Label Grid.Row="1" Grid.Column="0">Last Name</Label>
            <ListView Grid.Row="1" Grid.Column="1"
                      ItemsSource="{Binding People,Mode=OneWay}"
                      SelectedItem="{Binding SelectedPerson}">
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="First Name" Width="80" DisplayMemberBinding="{Binding FirstName}" />
                        <GridViewColumn Header="Last Name" Width="80" DisplayMemberBinding="{Binding LastName}" />
                        <GridViewColumn Header="Phone Number" Width="80" DisplayMemberBinding="{Binding PhoneNumber}" />
                        <GridViewColumn Header="Email" Width="80" DisplayMemberBinding="{Binding Email}" />
                    </GridView>
                </ListView.View>
            </ListView>
            <Grid Grid.Row="2" Grid.ColumnSpan="2">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <Button Grid.Column="1" MinHeight="26" MinWidth="80" Command="{Binding SearchCommand}">Search</Button>
            </Grid>
        </Grid>
    </Window>
    // ObservableObject.cs (if you use an MVVM framework, there will most likely be a different base object)
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool Set<T>(ref T field, T value, bool doNotCheckEquality = false, [CallerMemberName] string propertyName = null)
        {
            if (!doNotCheckEquality)
            {
                if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            }
            var args = new PropertyChangedEventArgs<T>(propertyName);
            field = value;
            RaisePropertyChanged(propertyName, args);
            return true;
        }
    }
    // RelayCommand.cs (just a simple version of RelayCommand; there are many different implementations)
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        [DebuggerStepThrough]
        public virtual bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        public virtual void Execute(object parameter)
        {
            _execute(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
