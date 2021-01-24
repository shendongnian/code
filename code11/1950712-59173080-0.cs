cs
public interface IFoo<out T>
{
	event Action<T> OnStateUpdated;
}
Classes implementation
cs
class Foo : IFoo<object>
{
	public event Action<object> OnStateUpdated;
	// Add method
	private void Button_Click(Object sender, EventArgs e)
	{
		OnStateUpdated?.Invoke("This will return data of type object");
	}
}
class Bar: IFoo<ValueType>
{
	public event Action<ValueType> OnStateUpdated;
	private new void Button_Click(Object sender, EventArgs e)
	{
		OnStateUpdated?.Invoke(default); // this returns data of type ValueType
	}
}
You also have to properly invoke the `Action` and check that it isn't `null`, null-conditional operator `?.` is helpful here
