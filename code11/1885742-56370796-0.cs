    public class Counter
    {
        public int Value { get; private set; }
        public void Increment() => Value++;
    }
public void Counter_increments()
{
    var subject = new Counter();
    subject.Increment();
    Assert.AreEqual(1, subject.Value());
}
Or perhaps the behavior that you want to test is your class's interaction with some dependency. There are a few ways to do that. One is to check the state of the dependency:
    public class ClassThatIncrementsCounter
    {
        public readonly Counter _counter;
        public ClassThatIncrementsCounter(Counter counter)
        {
            _counter = counter;
        }
        public void DoSomething()
        {
            // does something and then increments the counter
            _counter.Increment();
        }
    }
    [TestMethod]
    public void DoSomething_increments_counter()
    {
        var counter = new Counter();
        var subject = new ClassThatIncrementsCounter(counter);
        subject.DoSomething();
        Assert.AreEqual(1, counter.Value);
    }
You can also use a library like [Moq](https://github.com/Moq/moq4/wiki/Quickstart) to verify that your class interacted with a dependency:
    public class ClassThatIncrementsCounter
    {
        public readonly ICounter _counter;
        public ClassThatIncrementsCounter(ICounter counter)
        {
            _counter = counter;
        }
        public void DoSomething()
        {
            // does something and then increments the counter
            _counter.Increment();
        }
    }
    [TestMethod]
    public void DoSomething_increments_counter()
    {
        var counter = new Mock<ICounter>();
        // indicate that we want to track whether this method was called.
        counter.Setup(x => x.Increment()).Verifiable();
        var subject = new ClassThatIncrementsCounter(counter.Object);
        subject.DoSomething();
        // verify that the method was called.
        counter.Verify(x => x.Increment());
    }
----------
In order for this to work well, as you've noted, it's necessary to break methods down into smaller chunks that we can test in isolation. If a method makes lots of decisions then in order to test fully we'd need to test for every applicable combination, or every possible branch along which the code can execute. That's why a method with lots of conditions can be harder to test.
I spent some time looking at your code, but it's not clear enough what it's actually doing to make it easy to suggest how to refactor it. 
You can take larger chunks of code which get repeated like these:
            foreach (LaneIn laneIn in cr.LaneInList)
            {
                if (laneIn.Direction == "west")
                {
                    laneIn.EndLane = false;
                }
            }
            foreach (LaneIn laneIn in cr.LaneInList)
            {
                if (laneIn.Direction == "west")
                {
                    laneIn.EndLane = true;
                }
            }
...and replace them with methods like this, with the exception that you would give them clear, meaningful names. I can't do that since I'm not sure what they do:
public void SetEndLaneInDirection(List<LaneIn> laneInList, string direction, bool isEnd)
{
    foreach (LaneIn laneIn in laneInList)
    {
        if (laneIn.Direction == direction)
        {
            laneIn.EndLane = isEnd;
        }
    }
}
Now that one smaller piece of code is easier to test. Or, if you have a block of methods that all make some related update like this:
            cells[cellNr + 1].Crossing.IncomingStreams[1] = "";
            cells[cellNr + 1].Crossing.LaneOutList[1].EndLane = false;
            cr.Neighbours[1] = cells[cellNr + 1].Crossing;
            cells[cellNr + 1].Crossing.Neighbours[3] = cr;
Then put those in a method, and again, give it a clear name.
Now you can set up the class, call the method, and assert what you expect the state to be.
The side effect is that as you replace chunks of code with well-named method calls, your code becomes easier to read, because the method calls say, in near-English, what each step is doing.
It's much harder to do after the fact. Part of the challenge is learning to write code that's already easier to test. The good news is that as we do so our code naturally becomes simpler and easier to follow. And we have tests.
Here's a [great article](https://daedtech.com/intro-to-unit-testing-5-invading-legacy-code-in-the-name-of-testability/) on how to refactoring existing code to make it easier to test.
