xaml
<Window.Resources>
	<local:MyViewModel x:Key="viewModelInstance"></local:MyViewModel>
</Window.Resources>
<StackPanel>
	<Button DataContext="{StaticResource viewModelInstance}" Content="My Button">
		<Button.Style>
			<Style TargetType="Button">
				<!-- Default style is Visible and Enabled -->
				<Setter Property="IsEnabled" Value="True"></Setter>
				<Setter Property="Visibility" Value="Visible"></Setter>
				<Style.Triggers>
					<DataTrigger Binding="{Binding IsAllowed}" Value="False">
						<!-- Hide and disable when IsAllowed is false -->
						<Setter Property="IsEnabled" Value="False"></Setter>
						<Setter Property="Visibility" Value="Hidden"></Setter>
					</DataTrigger>
				</Style.Triggers>
			</Style>
		</Button.Style>
	</Button>
</StackPanel>
Assuming you have a view model class defined like:
cs
public class MyViewModel : INotifyPropertyChanged {
	public bool IsAllowed { get; set; } = true;
	//Put more logic here of course.
}
