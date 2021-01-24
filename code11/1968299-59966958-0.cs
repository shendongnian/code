csharp
[Test]
public void TestHandlingStrings() {
    var h1 = new StringHandler("handler 1");
    var h2 = new StringHandler("handler 2");
    int workersCount = activator.Bus.Advanced.Workers.Count;
    activator.Bus.Advanced.Workers.SetNumberOfWorkers(0);
    activator.Register(() => h1);
    activator.Register(() => h2);
    activator.Bus.Advanced.Workers.SetNumberOfWorkers(workersCount);
    activator.Bus.Advanced.SyncBus.SendLocal("Good day, sir.");
}
will exit almost immediately, so the bus is likely to never get to receive anything.
If you insert a little `Thread.Sleep(TimeSpan.FromSeconds(2));` at the end of the test, I bet your message will be received:
csharp
[Test]
public void TestHandlingStrings() {
    var h1 = new StringHandler("handler 1");
    var h2 = new StringHandler("handler 2");
    int workersCount = activator.Bus.Advanced.Workers.Count;
    activator.Bus.Advanced.Workers.SetNumberOfWorkers(0);
    activator.Register(() => h1);
    activator.Register(() => h2);
    activator.Bus.Advanced.Workers.SetNumberOfWorkers(workersCount);
    activator.Bus.Advanced.SyncBus.SendLocal("Good day, sir.");
    Thread.Sleep(TimeSpan.FromSeconds(2));
}
