/// <summary>
/// Base class that implements INotifyPropertyChanged
/// </summary>
public abstract class BindableBase: INotifyPropertyChanged
{
    // INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    public void RaisePropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    // update a property value, and fire PropertyChanged event when the value is actually updated
    protected bool Set<T>(string propertyName, ref T field, T newValue)
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue))
            return false;
        field = newValue;
        RaisePropertyChanged(propertyName);
        return true;
    }
    // update a property value, and fire PropertyChanged event when the value is actually updated
    // without having to pass in the property name
    protected bool Set<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
    {
        return Set(propertyName, ref field, newValue);
    }
}
You can now write your property definition as
public class Session: BindableBase
{
    private string sessionName;
    public string SessionName
    {
        get => sessionName;
        private set => Set(ref sessionName, value);
     }
}
