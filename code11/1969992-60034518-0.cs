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
