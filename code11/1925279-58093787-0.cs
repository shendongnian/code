public sealed class UpdateFooModel
{
	private int? _maxFoo;
	private int? _maxBar;
    [BindProperty] 
	public int? MaxFoo
	{ 
		get => _maxFoo;
		set
		{
			_maxFoo = value;
			MaxFooSet = true;
		}
	}
	
	public bool MaxFooSet { get; private set; }
	
    [BindProperty] 
	public int? MaxBar
	{ 
		get => _maxBar;
		set
		{
			_maxBar = value;
			MaxBarSet = true;
		}
	}
	
	public bool MaxBarSet { get; private set; }
}
Further improvements or other solutions are still welcome of course!
