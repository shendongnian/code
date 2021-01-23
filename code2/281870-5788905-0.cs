    public class Context : IDisposable {
        List<IDisposable> m_disposable = new List<IDisposable>();
        public void AddDisposable(IDisposable disposable) {
            m_disposable.Add(disposable); 
        }
        public void Dispose() {
            foreach (IDisposable disp in m_disposable)
                disp.Dispose(); 
        }
        // the Context class is used that way: 
        static void Main(string[] args) {
            using (Context context = new Context()) {
                // create your images here, add each to the context
                context.AddDisposable(image); 
                // add more objects here 
            } // <- leaving the scope will dispose the context
        }
    }
