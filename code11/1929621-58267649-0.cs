C#
private ObservableCollection<string> _myList;
// your control should bind to this property
public ObservableCollection<string> MyList
{
    get => return _myList;
    set
    {
        // assign a new value to the list
        _myList = value;
        // notify view about the change
        OnPropertiyChanged(nameof(MyList));
    }
}
// some logic in your view model
string newValue = "newValue";
_myList.Add(newValue );
OnPropertyCHanged(nameof(MyList));
Hope this helps.
