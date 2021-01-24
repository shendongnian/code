xaml
<Button Content="Capuccino + sugar" Command="{Binding DrinkCommand}">
	<Button.CommandParameter>
		<wpfapp1:MyCommandParameters Milk="false" Sugar="true"/>
	</Button.CommandParameter>
</Button>
Your class would look like 
cs
public class MyCommandParameters {
	public bool Milk { get; set; }
	public bool Sugar { get; set; }
}
and you could use it in your command code where it will be passed as argument.
