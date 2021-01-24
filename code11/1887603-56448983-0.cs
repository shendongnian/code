RecurringJob.AddOrUpdate<SomeService>(
    system, 
    s => s.DoWhateverThisServiceDoes(),
    appSettings.AuthInterval, 
    TimeZoneInfo.Local);
RecurringJob.AddOrUpdate<OtherService>(
    system, 
    o => o.DoOtherThing(),
    appSettings.AuthInterval, 
    TimeZoneInfo.Local);
What if you decide that you don't want these two services to run as separate tasks, but rather as part of a single task? You can do that too:
    public class CompositeService
    {
        private readonly SomeService _someService;
        private readonly OtherService _otherService;
        public CompositeService(SomeService someService, OtherService otherService)
        {
            _someService = someService;
            _otherService = otherService;
        }
        public async Task DoCompositeThing()
        {
            await Task.WhenAll(
                _someService.DoWhateverThisServiceDoes(),
                _otherService.DoOtherThing());
        }
    }
RecurringJob.AddOrUpdate<CompositeService>(
    system, 
    s => s.DoCompositeThing(),
    appSettings.AuthInterval, 
    TimeZoneInfo.Local);
A key point is that whether you decide to register them separately or create one task that executes both, you don't need to change how you write the individual classes. To decide whether to make them one class or separate classes you can apply the Single Responsibility Principle, and also consider what will make them easier to understand and unit test. Personally I'd lean toward writing smaller, separate classes.
Another factor is that the individual classes might have their own dependencies, like this:
    public class SomeService
    {
        private readonly IDependOnThis _dependency;
        public SomeService(IDependOnThis dependency)
        {
            _dependency = dependency;
        }
        public async Task DoWhateverThisServiceDoes()
        {
            // uses _dependency for something
        }
    }
This is more manageable if you keep classes separate. If they're all in one class and different methods depend on different things, you could end up with lots of unrelated dependencies and method crammed into one class. There's no need to do that. Even if we want all of the functionality "orchestrated" by one class, we can still write it as separate classes and then use another class to bring them together.
However many classes you create, you'll need to register them all with the `IServiceCollection`, along with their dependencies. You had mentioned that you don't want to register multiple services, but that's normal. If it gets large and out-of-control there are ways to break it up. 
