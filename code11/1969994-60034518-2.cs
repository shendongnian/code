public class BaseModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
public class ContactVm : BaseModel
{
    private string _firstName;
    public int Id { get; set; }
    public string FirstName
    {
        get { return _firstName; }
        set
        {
            this._firstName = value;
            NotifyPropertyChanged();
        }
    }
}
This is what I have in my callback. 
public void SelectContact(ContactVm contact)
{
    if (contact == null)
        return;
    contact.FirstName = "Test";
}
The only difference is I have implemented property changes for the ObservableCollection in ViewModel too. 
public ObservableCollection<ContactVm> ContactsToDisplay 
{
    get { return _contactsToDisplay; }
    set
    {
        this._contactsToDisplay = value;
        NotifyPropertyChanged();
    }
}
Note that I have not used your SelectedContact binding in my case. May be as you said that binding would be the issue. 
I hope it helps you. 
