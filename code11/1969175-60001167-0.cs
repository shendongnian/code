xaml
<ItemsControl ItemsSource="{Binding}">
	<ItemsControl.Resources>
		<local:EqualityConverter x:Key="EqualityConverter"/>
	</ItemsControl.Resources>
	<ItemsControl.ItemTemplate>
		<DataTemplate>
			<Grid >
				<Grid.ColumnDefinitions>
					<ColumnDefinition Width="2*"/>
					<ColumnDefinition Width="8*"/>
				</Grid.ColumnDefinitions>
				<Label Grid.Column="0" Content="{Binding .}" />
				<TextBox x:Name="textBox" Grid.Column="1">
					<TextBox.Style>
						<Style TargetType="TextBox">
							<Setter Property="BorderBrush" Value="Red" /> <!-- Default color -->
							<Style.Triggers>
								<DataTrigger Value="true">
									<DataTrigger.Binding>
										<MultiBinding Converter="{StaticResource EqualityConverter}">
											<Binding RelativeSource="{RelativeSource Mode=Self}" Path="Text"/>
											<Binding Path="."/>
										</MultiBinding>
									</DataTrigger.Binding>
									<Setter Property="BorderBrush" Value="Green" /> <!-- Color when values are equal -->
								</DataTrigger>
							</Style.Triggers>
						</Style>
					</TextBox.Style>
				</TextBox>
			</Grid>
		</DataTemplate>
	</ItemsControl.ItemTemplate>
</ItemsControl>
You need to define an additional piece of code (a `Converter`):
cs
/// <summary>
/// Returns true if all passed values are equal.
/// </summary>
public class EqualityConverter : IMultiValueConverter {
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		=> values.All(v => v.Equals(values[0]));
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		=> throw new NotImplementedException();
}
