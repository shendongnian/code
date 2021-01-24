 xaml
<Window.Resources>
    <local:MyCellBackgroundConverter x:Key="myCellBackgroundConverter"/>
</Window.Resources>
<Window.DataContext>
    <local:ViewModel/>
</Window.DataContext>
<Grid>
<!-- some your markup here -->
<DataGrid AutoGenerateColumns="False" ItemsSource="{Binding MyCollection}">
    <DataGridTextColumn Header="Column1" Binding="{Binding Value1}">
        <DataGridTextColumn.CellStyle>
            <Style TargetType="DataGridCell">
                <Setter Property="Background">
                    <Setter.Value>
                        <MultiBinding Converter="{StaticResource myCellBackgroundConverter}">
                            <Binding Path="Value1"/>
                            <Binding Path="Value2"/>
                        </MultiBinding>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
    <DataGridTextColumn Header="Column2" Binding="{Binding Value2}"/>
</DataGrid>
</Grid>
The ViewModel Class
 c#
using System.Collections.ObjectModel;
using System.ComponentModel;
// ...
public class ViewModel : INotifyPropertyChanged
{
    private ObservableCollection<MyItem> _myCollection = new ObservableCollection<MyItem>();
    public ObservableCollection<MyItem> MyCollection
    {
        get => _myCollection;
        set
        {
            _myCollection = value;
            OnPropertyChanged(nameof(MyCollection));
        }
    }
    public ViewModel()
         // you may load or add the data to MyCollection here
    {
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
Item
 c#
using System.ComponentModel;
// ...
public class MyItem : INotifyPropertyChanged
{
    private string _value1 = string.Empty;
    private string _value2 = string.Empty;
    public string Value1
    {
        get => _value1;
        set { _value1 = value; OnPropertyChanged(nameof(Value1)); }
    }
    public string Value2
    {
        get => _value2;
        set { _value2 = value; OnPropertyChanged(nameof(Value2)); }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
And finally the Converter
 c#
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
//...
public class MyCellBackgroundConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[0] is string value1 && values[1] is string value2)
        {
            if (value1.Length > 0)
            {
                return Brushes.Green;
            }
            else
            if (value2.Length > 0)
            {
                return Brushes.Yellow;
            }
            else
                return Brushes.Red;
        }
        else return Brushes.White;
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => null;
}
In alternative way you may use `Style.DataTriggers` directly in XAML.
For additional information about bindings and properties look for **MVVM** programming pattern. In short you're not need `x:Name` anymore because in **MVVM** pattern you interacting only with ViewModel class data instances and can't interact with contols directly there (and that's fine). Meanwhile Contols automatically sync with data binded to them. Calling `OnPropertyChanged("PropertyName")` here simply cause the GUI refresh.
In relation to markup of your XAML example, try wrapping the Control groups in `StackPanel` and learn about it. It will save your time spent fighting with margins. Simply set few colums and/or rows in Window's `Grid` and place StackPanels there assigning `Grid.Column` and `Grid.Row` to them.
-------------------------
**ADDITION:**
> How in my case I should setup ItemSource for binding? Should I import databases to List first and then Bind to the list?
`ObservableCollection<>` is same as `List<>` and you may use it in the same way. The difference that first one implements `CollectionChanged` event that notifies DataGrid if any items was added or removed from the collection.
Your `Button.Click` event handler contains redundant async/await declaration.
Let's move forward and see how it can be done with **MVVM**.
XAML
 xaml
<Button Content="Go" Command="{Binding myCommand}"/>
Command must implement ICommand interface. You have to do 2 things for proper implementation:
1) Add `RelayCommand` separate Class implementing `ICommand` interface
 c#
public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    public CustomCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        
    public void Execute(object parameter) => _execute(parameter);
}
2) Add the Command instance to your `ViewModel` class
 c#
public ICommand myCommand => new RelayCommand(obj =>
{
    // do the same here as in Button.Click above
});
Next, you may need some blocking UI thing that will prevent user from any actions while data is loading.
ViewModel
 c#
private bool _allowUIChanges = true;
public bool AllowUIChanges
{
    get => _allowUIChanges;
    set
    {
        _allowUIChanges = value;
        OnPropertyChanged(nameof(AllowUIChanges));
    }
}
Finally bind your Control properties to it
XAML
 xaml
<Button Content="Go" Command="{Binding myCommand}" Enabled="{Binding AllowUIChanges}"/>
<DataGrid IsReadOnly="{Binding AllowUIChanges}" AutoGenerateColumns="False" ItemsSource="{Binding MyCollection}">
Then set `AllowUIChanges` to `false` while data is loading.
