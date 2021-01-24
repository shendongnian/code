cs
public class ChildEvent
{
	public string Name { get; set; }
}
public class ParentEvent
{
	public string Name { get; set; }
}    
cs
public class ShellViewModel : Conductor<object>, IHandle<ChildEvent>
{
	private readonly IEventAggregator _events;
	public ShellViewModel(IEventAggregator events)
	{
		_events = events;
		events.Subscribe(this);
	}
	private string _test;
	public string Test
	{
		get => _test;
		set
		{
			_test = value;
			NotifyOfPropertyChange(() => Test);
		}
	}
	public void Handle(ChildEvent message)
	{
		Test = message.Name;
	}
}
public class Module1ViewModel : Screen, IHandle<ParentEvent>
{
	private readonly IEventAggregator _events;
	public Module1ViewModel(IEventAggregator events)
	{
		_events = events;
		events.Subscribe(this);
	}
	private string _firstName;
	public string FirstName
	{
		get => _firstName;
		set
		{
			_firstName = value;
			NotifyOfPropertyChange(() => FirstName);
		}
	}
	public void Handle(ParentEvent message)
	{
		FirstName = message.Name;
	}
}
Btw, you don't need a `Module1ViewModel` reference in `ShellViewModel` in case of using an `IEventAggregator`
