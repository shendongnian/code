 xaml
<Setter Property="IsSelected" Value="{Binding IsSelected, UpdateSourceTrigger=PropertyChanged}" />
Property `IsSelected` must present in the class that binded to Control's `DataContext` implementing `INotifyPropertyChanged` interface, this way
 c#
private _bool _isSelected
public bool IsSelected
{
    get => _isSelected;
    set
    {
        _isSelected = value;
        OnPropertyChanged(nameof(IsSelected));
    }
}
