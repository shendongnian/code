 xaml
<Window.Resources>
    <local:MyCellBackgroundConverter x:Key="myCellBackgroundConverter"/>
</Window.Resources>
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
Data instance
 c#
using System.Collections.ObjectModel;
// ...
public ObservableCollection<MyItems> MyCollection = new ObservableCollection<MyItems>() { get; set; };
Item
 c#
using System.ComponentModel;
// ...
public class MyItems : INotifyPropertyChanged
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
    protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
For additional information about bindings and properties look for **MVVM** programming pattern.
