cs
public class IdToBrushConverter : IValueConverter {
	/// <summary>
	/// Converts an ID into a Brush
	/// </summary>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
		return new SolidColorBrush(IdColors[value]); //need for example some static access to IdColors here
		//You can also define IdColors here or use other custom logic.
	}
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
		throw new NotImplementedException();
	}
}
And in your XAML, you can call the converter like this:
xaml
<DataGrid Name="TheGrid" AutoGenerateColumns="False" CanUserAddRows="False CanUserDeleteRows="False">
  <DataGrid.Resources>
	<!--You might need some namespace prefix here-->
	<view:IdToBrushConverter x:Key="IdToBrushConverter"></view:IdToBrushConverter>
    <Style.Setters>
      <Setter Property = "Background" Value="{Binding Path=Id, Converter={StaticResource IdToBrushConverter}" ></Setter>
    </Style.Setters>
  </DataGrid.Resources>
  <DataGrid.Columns>
    <DataGridTextColumn Header="Id" Binding="{Binding Id}"/>
    <DataGridTextColumn Header="Time" Binding="{Binding Time}"/>
    ...
  </DataGrid.Columns>
</DataGrid>
The converter will be called and applied to the ```Id``` property and return a ```SolidColorBrush``` with the color you want.
