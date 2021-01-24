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
**Fixing the issue in a WPF-oriented way**
An even better way to achieve what you want is to define a correct view model from the start:
cs
public class QuestionViewModel {
    public string RequiredText { get; set; }
    public string InputText{ get; set; }
    public bool IsCorrect => RequiredText.Equals(InputText);
}
(It should implement `INotifyPropertyChanged` but for simplicity I haven't shown that)
And you would bind your `ItemsControl.ItemsSource` to a collection of `QuestionViewModel` instead of a collection of `string`:
xaml
<ItemsControl ItemsSource="{Binding Questions}">
	<ItemsControl.ItemTemplate>
		<DataTemplate>
			<Grid >
				<Grid.ColumnDefinitions>
					<ColumnDefinition Width="2*"/>
					<ColumnDefinition Width="8*"/>
				</Grid.ColumnDefinitions>
				<Label Grid.Column="0" Content="{Binding RequiredText}" />
				<TextBox x:Name="textBox" Grid.Column="1" Text="{Binding InputText}">
					<TextBox.Style>
						<Style TargetType="TextBox">
							<Setter Property="BorderBrush" Value="Red" />
							<Style.Triggers>
								<DataTrigger Binding="{Binding IsCorrect}"  Value="true">
									<Setter Property="BorderBrush" Value="Green" />
								</DataTrigger>
							</Style.Triggers>
						</Style>
					</TextBox.Style>
				</TextBox>
			</Grid>
		</DataTemplate>
	</ItemsControl.ItemTemplate>
</ItemsControl>
You should have a look at the MVVM pattern probably.
