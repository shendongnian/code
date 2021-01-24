internal object _Value = null;
internal object Value
{
    get
    {
        return _Value;
    }
    set
    {
        if ((value == null && _Value != null) ||
            (value != null && _Value == null) ||
            (value != null && _Value != null && !_Value.Equals(value)))
        {
            _Value = value;
            Changed?.Invoke(this, new SettingValueChangedEventArgs()
            {
                IsInitialization = FirstChangeIsInitialization
            });
        }
    }
}
