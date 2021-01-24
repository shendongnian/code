xaml
<ListView ItemsSource="{Binding MyList}">
	<ListView.Resources>
		<local:GridRowPresenterToDataContextPropertiesConverter x:Key="GridRowPresenterToDataContextPropertiesConverter"></local:GridRowPresenterToDataContextPropertiesConverter>
		<Style TargetType="TextBlock">
			<Setter Property="TextTrimming" Value="CharacterEllipsis" />
			<Setter Property="TextWrapping" Value="NoWrap"/>
			<Setter Property="FontFamily" Value="Segue UI Light" />
			<Setter Property="FontSize" Value="13" />
			<!--THIS IS THE NEW PART-->
			<Setter Property="ToolTip">
				<Setter.Value>
					<MultiBinding Converter="{StaticResource GridRowPresenterToDataContextPropertiesConverter}"
								  ConverterParameter="Name, Value">
						<Binding RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=GridViewRowPresenter}"/>
						<Binding RelativeSource="{RelativeSource Mode=Self}"/>
					</MultiBinding>
				</Setter.Value>
			</Setter>
			<!--END OF THE NEW PART-->
		</Style>
	</ListView.Resources>
	<ListView.View>
		<GridView>
			<GridViewColumn Header="Templates" Width="200" DisplayMemberBinding="{Binding Name}"/>
			<GridViewColumn Header="Templates" Width="200" DisplayMemberBinding="{Binding Value}"/>
		</GridView>
	</ListView.View>
</ListView>
I added a simple view model class and another `GridViewColumn` for testing purposes:
cs
public class MyViewModel {
	public string Name { get; set; } = "Hello.";
	public string Value { get; set; } = "world.";
}
This XAML will set the `Name` property of the `DataContext` as `ToolTip` for all `TextBlocks` in the first column, and the `Value` property of the `DataContext` as `ToolTip` for all `TextBlocks` in the second column. You can handle additional columns by adding to the `ConverterParameter="Name, Value"` ordered list of properties.
The key is in the definition of `GridRowPresenterToDataContextPropertiesConverter` (which is one of the least straightforward and most hacky `IMultiValueConverter` I might have ever written):
cs
public class GridRowPresenterToDataContextPropertiesConverter : IMultiValueConverter {
	public static T FindVisualSelfOrChildren<T>(DependencyObject parent) where T : DependencyObject {
		if (parent == null) return null;
		if (parent is T) return parent as T;
		IEnumerable<DependencyObject> children = Enumerable.Range(0, VisualTreeHelper.GetChildrenCount(parent)).Select(i => VisualTreeHelper.GetChild(parent, i));
		foreach (var child in children) {
			T result = FindVisualSelfOrChildren<T>(child);
			if (result != null) return result as T;
		}
		return null;
	}
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
		var presenter = (GridViewRowPresenter)values[0];
		var targetElement = values[1] as FrameworkElement;
		var sourceProperties = ((string)parameter).Split(',');
		
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(presenter); i++) {
			var child = VisualTreeHelper.GetChild(presenter, i);
			if (FindVisualSelfOrChildren<TextBlock>(child) == targetElement) {
				var dataContext = targetElement.DataContext;
				return dataContext.GetType().GetProperty(sourceProperties[i].Trim()).GetValue(dataContext);
			}
		}
		return "";
	}
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
This converter takes the target element (here, it's gonna be each `TextBlock`), figures out in which column of the `GridView` is lives and extracts the property at the correct index from the `ConverterParameter`.
This answer is more written for fun than for use in production code though, and it will need some smarter code to handle re-ordering of columns which is absolutely not supported now.
