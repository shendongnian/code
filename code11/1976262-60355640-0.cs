 c#
public class FirstClass : INotifyPropertyChanged
{
    SecondClass secondClass = new SecondClass();
    private bool _firstProperty;
    public bool FirstProperty
    {
        get => _firstProperty;
        set
        {
            _firstProperty = value;
            OnPropertyChanged(nameof(FirstProperty));
        }
    }
    private void SecondClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(secondClass.SecondProperty)) FirstProperty = secondClass.SecondProperty;
    }
    public FirstClass()
    {
        secondClass.PropertyChanged += SecondClass_PropertyChanged;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
public class SecondClass : INotifyPropertyChanged
{
    private bool _secondProperty;
    public bool SecondProperty
    {
        get => _secondProperty;
        set
        {
            _secondProperty = value;
            OnPropertyChanged(nameof(SecondProperty));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
In this example any change of `SecondProperty` will cause change of the `FirstProperty`.
