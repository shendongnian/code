 csharp
public class GroupModel
{
    public GroupModel(uint id, string name)
    {
        Id = id;
        Name = name;
    }
    public uint Id { get; }
    public string Name { get; }
}
public class UserModel
{
    public UserModel(uint id, string firstName, string surname, DateTime dateOfBirth)
    {
        Id = id;
        FirstName = firstName;
        Surname = surname;
        DateOfBirth = dateOfBirth;
    }
    public uint Id { get; }
    public string FirstName { get; }
    public string Surname { get; }
    public DateTime DateOfBirth { get; }
}
### ViewModels
#### Base classes
 csharp
public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
public abstract class ViewModelBase<TModel> : ViewModelBase
    where TModel : class
{
    private TModel _model;
    public ViewModelBase(TModel model)
        => _model = model;
    /*
     * There is a design choice here to allow the model
     * to be swapped at runtime instead or to treat the
     * view model as immutable in which case the setter
     * for the Model property should be removed.
     */
    public TModel Model
    {
        get => _model;
        set
        {
            if (ReferenceEquals(_model, value))
            {
                return;
            }
            _model = value;
            OnPropertyChanged();
        }
    }
}
#### Concrete classes
 csharp
public class GroupViewModel : ViewModelBase<GroupModel>
{
    public GroupViewModel(GroupModel model)
        : base(model)
    {
    }
    public ObservableCollection<UserViewModel> Users { get; }
        = new ObservableCollection<UserViewModel>();
    public void AddUser(UserModel user)
    {
        var viewModel = new UserViewModel(user);
        Users.Add(viewModel);
    }
}
public class UserViewModel : ViewModelBase<UserModel>
{
    public UserViewModel(UserModel model)
        : base(model)
    {
    }
    // convenience property; could be done completely in XAML as well
    public string FullName => $"{Model.FirstName} {Model.Surname}";
}
public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        // create sample user groups
        for (var groupIndex = 1u; groupIndex <= 5u; ++groupIndex)
        {
            var groupName = $"Group {groupIndex}";
            var groupModel = new GroupModel(groupIndex, groupName);
            var groupViewModel = new GroupViewModel(groupModel);
            UserGroups.Add(groupViewModel);
            for (var userIndex = 1u; userIndex <= 5u; ++userIndex)
            {
                var userModel = new UserModel(
                    id: userIndex,
                    firstName: "John",
                    surname: $"Smith",
                    dateOfBirth: DateTime.Today);
                groupViewModel.AddUser(userModel);
            }
        }
    }
    public ObservableCollection<GroupViewModel> UserGroups { get; }
        = new ObservableCollection<GroupViewModel>();
}
### View
 xaml
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:viewModels="clr-namespace:UserGroups.ViewModels"
        x:Class="UserGroups.Views.MainWindow"
        Title="User Groups"
        Width="1024"
        Height="768">
    <Window.DataContext>
        <viewModels:MainViewModel />
    </Window.DataContext>
    <Grid>
        <TreeView ItemsSource="{Binding Path=UserGroups}">
            <TreeView.Resources>
                <!-- Template for Groups -->
                <HierarchicalDataTemplate DataType="{x:Type viewModels:GroupViewModel}"
                                          ItemsSource="{Binding Path=Users}">
                    <TextBlock Text="{Binding Path=Model.Name}" />
                </HierarchicalDataTemplate>
                <!-- Template for Users -->
                <DataTemplate DataType="{x:Type viewModels:UserViewModel}">
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Path=Model.Id, StringFormat='[{0}]'}"
                                   Margin="3,0" />
                        <TextBlock Text="{Binding Path=FullName}"
                                   Margin="3,0" />
                    </StackPanel>
                </DataTemplate>
            </TreeView.Resources>
        </TreeView>
    </Grid>
</Window>
Here's what you end up with:
[![enter image description here][1]][1]
There are lots of frameworks that take care of a lot of the tedious work of working with the MVVM pattern (e.g. removing most/all of the boilerplate code for INotifyPropertyChanged).  Here are just a few to look at:
* [MVVM Light Toolkit](http://www.mvvmlight.net/)
* [Prism](https://prismlibrary.github.io/docs/)
* [ReactiveUI](https://reactiveui.net/)
Some additional resources that might also be useful:
* [SnoopWPF](https://github.com/snoopwpf/snoopwpf)
* [WPF Tutorial](http://wpftutorial.net/)
  [1]: https://i.stack.imgur.com/uTP7R.png
