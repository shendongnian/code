 c#
public bool IsChecked
    {
        get
        {
            return _isChecked;
        }
        set
        {
            _isChecked = value;
            if (value)
            {
                if (!_checked.Contains(this))
                {
                    _checked.Add(this);
                    NotifyPropertyChanged("IsChecked");
                }
            }
            else
            {
                if (_checked.Contains(this))
                {
                    _checked.Remove(this);
                    NotifyPropertyChanged("IsChecked");
                }
            }
        }
    }
`NotifyPropertyChanged` fires `PoropertyChanged` Event with a string parameter you passing to. Meanwhile `Binding` will receive it.
**So, here's 2 friends**
 xaml
<Setter Property="IsSelected" Value="{Binding IsChecked, Mode=TwoWay}" />
and
 c#
NotifyPropertyChanged("IsChecked");
If you need tune the update behavior of your control, pass `UpdateSourceTrigger` setting to to the binding, this way:
 xaml
<Setter Property="IsSelected" Value="{Binding IsChecked, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
Additionally: `TwoWay` is default for the `Mode` here. You may not declare it.
