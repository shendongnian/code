    public interface IHaveAnEvent
    {
        event EventHandler MyEvent;
    }
    // In your test...
    var fake = A.Fake<IHaveAnEvent>();
    var handler = new EventHandler((s, e) => { });
    fake.MyEvent += handler;
    A.CallTo(fake).Where(x => x.Method.Name.Equals("add_MyEvent")).WhenArgumentsMatch(x => x.Get<EventHandler>(0).Equals(handler)).MustHaveHappened();
