    public class Fixture : ReactiveTest {
    
      public void SomethingHappenedTest() {
        // Arrange 
        var scheduler = new TestScheduler();
        var classUnderTest = new ClassUnderTest();
        
        // Act 
        scheduler.Schedule(TimeSpan.FromTicks(20), () => classUnderTest.DoSomething());
        var actual = scheduler.Start(
          () => classUnderTest.SomethingHappened,
          created: 0,
          subscribed: 10,
          disposed: 100
        );
      
        // Assert
        var expected = new[] { OnNext(20, new Unit()) };
        ReactiveAssert.AreElementsEqual(expected, actual.Messages);
      }
      
    }
