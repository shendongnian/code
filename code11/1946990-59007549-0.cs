cs
public class Foo : INotifyPropertyChanged
{
    public int X { get; private set; } // No PropertyChanged event here
    public int Y { get; private set; } // No PropertyChanged event here
	
	public void ModifyXandY()
	{
		foo.X = 2;
		ModifyYPrivate();
	    // State is now consistent
		RaisePropertyChanged(nameof(X));
		RaisePropertyChanged(nameof(Y));
	}
	public void ModifyY()
	{
		ModifyYPrivate();
		RaisePropertyChanged(nameof(Y));
	}
	
	private void ModifyYPrivate()
	{
		foo.Y = 1;
	}
	
	#region INotifyPropertyChanged Members
	public event PropertyChangedEventHandler PropertyChanged;
	
	private RaisePropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	#endregion
}
This appears a bit risky because you might still privately change `X` or `Y and forget to raise the events.
**Better idea: *make your state always consistent* and don't bother about change notifications**
You could change the above code to make the idea of *consistency* a key principle in your `Foo` class by making part of its state *immutable*.
The key is *making changes to the `Foo` class consistent right from the start, instead of wondering when to notify of state changes.*
You could change its couple of properties `X` and `Y` to an immutable `struct` holding both `X` and `Y`:
cs
public readonly struct ConsistentXY
{
    public readonly double X;
    public readonly double Y;
    public Point(double x, double y) => (X, Y) = (x, y);
}
And then you could implement `INotifyPropertyChanged` in a normal way.
cs
public class Foo : INotifyPropertyChanged
{
    private ConsistentXY _state;
	public ConsistentXY State
	{
		get => _state;
		set
		{
			_state = value;
			RaisePropertyChanged(nameof(State));
		}
	}
	
    public int X => State.X;
    public int Y => State.Y;
	
	public void ModifyXandY()
	{
		State = new ConsistentXY(2, 1);
	}
	
	#region INotifyPropertyChanged Members
	/* ...same code... */
	#endregion
}
That would force you to change some code to ensure that all modifications you make to `State` are consistent but that's pretty legit to ensure consistency of state.
