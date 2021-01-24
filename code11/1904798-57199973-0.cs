public class Api
{
	public event EventHandler<string> ValueChanged;
	public string SomeMethod(string a)
	{
		//do your logic here, if true then invoke the event
		if (a.Length > 0)
		{
			ValueChanged?.Invoke(EventArgs.Empty, "String length is greater than zero!!!");			
		}
		return a.ToUpper();
	}
}
What you need is to implement an event inside your api and call it if some logic occurs and then invoke the event if is not null. It's up to you what kind of datatype of the event, in example above i use string.
