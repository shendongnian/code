public class MainViewModel : ViewModelBase
{
    private readonly IEventAggregator _eventAggregator;
    public MainViewModel(IEventAggregator eventAggreator)
    {
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<MyEventOne>().Subscribe(() => DoSomething());
        _eventAggregator.GetEvent<MyEventTwo>().Subscribe(() => DoSomething());
        _eventAggregator.GetEvent<MyEventThree>().Subscribe(() => DoSomething());
    }
}
There is no need to take a new instance each time. But you should  register  logger in container as singleton.
