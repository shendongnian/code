    class SampleClass : IDisposable {
        public void Dispose() {
            Console.WriteLine("Execute Dispose!");
        }
    }
    static void Main(string[] args) { 
        using (SampleClass sc = new SampleClass()) {
            throw new Exception();
        }
    }
