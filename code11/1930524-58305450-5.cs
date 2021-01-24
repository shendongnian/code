C#
public class ViewModelBase : INotifyPropertyChanged
{
    //  Copy your INotifyPropertyChanged implementation here from your main viewmodel
    //  Make your main viewmodel inherit from ViewModelBase
}
//  Formerly PersonViewModel
public class MainViewModel : ViewModelBase
{
    //  We need this to be the actual type because we'll need to be calling 
    //  RaiseCanExecuteChanged() on it. Or whatever equivalent. 
    private RelayCommand _addPerson;
    //  All the stuff PersonViewModel had.
    //  Stuff
    //  Stuff
    //  Stuff
}
//  Remember, your old PersonViewModel is now named MainViewModel. This is the class 
//  that you used to call Person. 
public class PersonViewModel : ViewModelBase
{
    public string FullName
    {
        get
        {
            return _firstName + " " + _lastName;
        }
        //  No empty set, not ever. Somebody will try to set FullName and the compiler 
        //  will let him think it worked. But nothing will change. That's a bug. 
        //set { }
    }
    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            _firstName = value;
            //  Do the same for LastName. Careful you don't pass nameof(FirstName) 
            // over there. 
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(FullName));
        }
    }
Now the UI knows when those properties change, but the main viewmodel still doesn't. But now that we have notifications from `Person`, that's solvable. We have to rewrite NewPerson again:
    private PersonViewModel _newPerson = null;
    public PersonViewModel NewPerson
    {
        get { return _newPerson; }
        set
        {
            if (value != _newPerson)
            {
                //  Take the handler off the old NewPerson, if any. 
                if (_newPerson != null)
                {
                    _newPerson.PropertyChanged -= NewPerson_PropertyChanged;
                }
                _newPerson = value;
                if (_newPerson != null)
                {
                    _newPerson.PropertyChanged += NewPerson_PropertyChanged;
                }
                OnPropertyChanged(nameof(NewPerson));
                OnPropertyChanged(nameof(AddPersonCanExecute));
                //  I don't know what your RelayCommand class looks like, but it should 
                //  provide some way to force it to raise its CanExecuteChanged event. 
                //  That's what the Button is waiting for to enable or disable itself. 
                _addPerson.RaiseCanExecuteChanged()
            }
        }
    }
    private void NewPerson_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Person.FirstName):
            case nameof(Person.LastName):
                OnPropertyChanged(nameof(AddPersonCanExecute));
                AddPerson
                break;
        }
    }
<hr/>
Another point: Don't make your viewmodel a resource. It's not breaking your code, but it serves no purpose and creates extra work for you. 
XAML
<Window.DataContext>
    <ViewModel:PersonViewModel />
</Window.DataContext>
<Window.Resources>
    <!-- remove it from here -->
</Window.Resources>
Now for all controls belonging to the Window itself, all your bindings can look like this:
    <TextBox 
        Text="{Binding NewPerson.FirstName, UpdateSourceTrigger=PropertyChanged}"  
        Grid.Row="2" 
        HorizontalAlignment="Left" 
        Grid.Column="2" 
        Height="40" Width="200" Margin="10 5"
        />
Get rid of Mode=TwoWay on TextBox.Text; that property will cause bindings on it to be TwoWay by default. Keep `UpdateSourceTrigger=PropertyChanged` only on TextBox.Text: That will cause the textbox to update the viewmodel on every keystroke, instead of the default behavior of updating the viewmodel property only when the textbox loses focus. You don't need `UpdateSourceTrigger=PropertyChanged` on the command binding or the Label.Content binding, because those properties *cannot ever* update the viewmodel property. They're OneWay by default, and by the nature of what they do. 
