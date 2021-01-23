    public interface IFoo
    {
        event EventHandler Testing;
        void Test();
    }
    public class Foo : IFoo
    {
        public event EventHandler Testing;
        protected void OnTesting(EventArgs e)
        {
            if (Testing != null)
                Testing(this, e);
        }
        public void Test()
        {
            OnTesting(EventArgs.Empty);
        }
    }
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IFoo f = new Foo();
            f.Testing += new EventHandler(f_Testing);
            f.Test();
        }
    
        static void f_Testing(object sender, EventArgs e)
        {
            IFoo foo = sender as IFoo;
            if (foo != null)
            { 
                //...
            }
        }
    }
