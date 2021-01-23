    using System;
    using System.Timers;
    public class MainForm
    {
        public MainForm()
        {
            var tm = new TestManager(exception =>
            {
                //do somthing with exception
                //note you are still on the timer event thread
            });
        }
    }
    public class TestManager
    {
        private readonly Action<Exception> _onException;
        public TestManager(System.Action<System.Exception> onException )
        {
            _onException = onException;
        }
        private System.Timers.Timer _timer;
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                doSomeDatabaseActions();
            }
            catch (Exception ex)
            {
                //throw new ApplicationException("How do I get this error back into main thread...", ex);
                _onException(ex);
            }
        }
    }
