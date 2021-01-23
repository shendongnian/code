    public interface IIdlingSource
    {
        event EventHandler Idle;
    }
    public sealed class ApplicationIdlingSource : IIdlingSource
    {
        public event EventHandler Idle
        {
            add { System.Windows.Forms.Application.Idle += value; }
            remove { System.Windows.Forms.Application.Idle -= value; }
        }
    }
    public class MyClass
    {
        public MyClass(IIdlingSource idlingSource)
        {
            idlingSource.Idle += OnIdle;
        }
        private void OnIdle(object sender, EventArgs e)
        {
            ...
        }
    }
    // Usage
    new MyClass(new ApplicationIdlingSource());
