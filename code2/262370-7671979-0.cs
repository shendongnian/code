    <Window x:Class="WpfApplication12.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:WpfApplication12="clr-namespace:WpfApplication12"
            Title="MainWindow" Height="350" Width="525">
        <Window.DataContext>
            <WpfApplication12:MainWindowViewModel />
        </Window.DataContext>
        <Grid>
            <DataGrid ItemsSource="{Binding PersonList}">
                
            </DataGrid>
        </Grid>
    </Window>
...
    public class MainWindowViewModel : INotifyPropertyChanged
        {
            public MainWindowViewModel()
            {
                PersonList = new ObservableCollection<Person>()
                                 {
                                     new Person(){Name="Bobby"}
                                 };
            }
    
            public ObservableCollection<Person> PersonList { get; set; }
    
    
            public void OnPropertyChanged(string p)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        public class Person : INotifyPropertyChanged
        {
            private string name;
    
            public string Name
            {
                get { return name; }
                set
                {
                    if (name != value)
                    {
                        name = value;
                        OnPropertyChanged("Name");
                    }
                }
            }
    
            public void OnPropertyChanged(string p)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
