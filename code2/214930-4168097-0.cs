    public interface IInputProcessor
    {
        void ProcessInput(Object sender, FileSystemEventArgs e);
    }
    public class ClassUnderTest
    {
        public ClassUnderTest(IInputProcessor inputProcessor)
        {
            this.inputProcessor = inputProcessor;
        }
        public void ListenPath(string path){
            // Your existing code ...
            objFileWatcher.Created +=
                new FileSystemEventHandler(inputProcessor.ProcessInput);
            // ...
        }
        private IInputProcessor inputProcessor;
    }
    public class MockInputParser : IInputProcessor
    {
        public MockInputParser()
        {
            this.Calls = new List<ProcessInputCall>();
        }
        public void ProcessInput(Object sender, FileSystemEventArgs args)
        {
            Calls.Add(new ProcessInputCall() { Sender = sender, Args = args });
        }
        public List<ProcessInputCall> Calls { get; set; }
    }
    public class ProcessInputCall
    {
        public Object Sender;
        public FileSystemEventArgs Args;
    }
    [Test]
    public void Test()
    {
        const string somePath = "SomePath.txt";
        var mockInputParser = new MockInputParser();
        var classUnderTest = new ClassUnderTest(mockInputParser);
        classUnderTest.ListenPath(somePath);
        // Todo: Write to file at "somePath"
        Assert.AreEqual(1, mockInputParser.Calls.Count);
        // Todo: Assert other args
    }
