    public class MembaseTap
    {
        public void Tap()
        {
            var options = new Dictionary<string, object>();
            options["Arguments"] = new [] { "foo", "bar" };
            var pyEngine = Python.CreateEngine(options); 
            pyEngine.ExecuteFile(@"E:\Program Files\Membase\Server\bin\tap_example.py"); 
        }
    }
