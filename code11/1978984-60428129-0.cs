 xaml
<Window x:Class="PersonApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:MyApp"
        Title="MainWindow" Height="350" Width="525">
    <Window.DataContext>
        <local:MainViewModel/>
    </Window.DataContext>
    <Grid>
        <ListView ItemsSource="{Binding PersonList}">
            <ListView.View>
                <GridView >
                    <GridViewColumn Header="Name" DisplayMemberBinding="{Binding MyName}"/>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
</Window>
**Code behind**
MainWindow.xaml.cs
 c#
using System.Windows;
namespace PersonApp
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
**ViewModel** - for the View of Main Window
MainViewModel.cs
 c#
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace PersonApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _personList = new ObservableCollection<Person>();
        public ObservableCollection<Person> PersonList
        {
            get => _personList;
            set
            {
                _personList = value;
                OnPropertyChanged(nameof(PersonList));
            }
        }
        public MainViewModel()
        {
            // fill or load your PersonList here
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
**Person ViewModel** - for the item of your list
Person.cs
 c#
using System.ComponentModel;
namespace PersonApp
{
    public class Person : INotifyPropertyChanged
    {
        private string _myName;
        public string MyName
        {
            get => _myName;
            set
            {
                _myName = value;
                OnPropertyChanged(nameof(MyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
In case of question "Where is the `Model`?", Model is class(es) where you do your job connecting your ViewModels and Web, disk, make calculations, etc. You may add and empty class `Model` and make its instance in MainViewModel this way:
c#
private Model myModel;
public MainViewModel()
{
     myModel = new Model();
     // fill or load your PersonList here
}
