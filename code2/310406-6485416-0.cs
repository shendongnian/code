    public interface IEventProvider
    {
        event EventHandler OnEvent;
    }
    public class Example
    {
        public Example(IEventProvider e)
        {
            e.OnEvent += PerformWork;
        }
        private void PerformWork(object sender, EventArgs e)
        {
            // perform work
            // event has an impact on this class that can be observed
            //   from the outside.  this is just an example...
            VisibleSideEffect = true;
        }
        public bool VisibleSideEffect
        {
           get; set;
        }
    }
    [TestClass]
    public class ExampleFixture
    {
        [TestMethod]
        public void DemonstrateThatTheClassRespondsToEvents()
        {
            var eventProvider = new Mock<IEventProvider>().Object;
            var subject = new Example(eventProvider.Object);
            Mock.Get(eventProvider)
                .Raise( e => e.OnEvent += null, EventArgs.Empty);
            Assert.IsTrue( subject.VisibleSideEffect, 
                           "the visible side effect of the event was not raised.");
        }
    }
