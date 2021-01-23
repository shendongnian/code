    [TestFixture]
    public sealed class TestStubbingEvents
    {
        [Test]
        public void FooReceivesEventFromBar()
        {
            BarStub bar = new BarStub(); 
            Foo foo = new Foo(bar);
            Assert.That(foo.EventReceived, Is.False);
            bar.RaiseBarEvent();
            Assert.That(foo.EventReceived, Is.True);
        }
    }
    internal class Foo
    {
        public bool EventReceived
        {
            get; set;
        }
        public Foo(IBar bar)
        {
            EventReceived = false;
            bar.BarEvent += ReceiveBarEvent; 
        }
        private void ReceiveBarEvent(object sender, EventArgs args)
        {
            EventReceived = true; 
        }
        
    }
    internal class BarStub : IBar
    {
        public event BarEventHandler BarEvent;
        //Stub method that invokes the event
        public void RaiseBarEvent()
        {
            BarEvent.Invoke(this, new EventArgs());
        }
    }
    
    public delegate void BarEventHandler(object sender, EventArgs args);
    
    public interface IBar
    {
        event BarEventHandler BarEvent;
    }
