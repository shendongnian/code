    public class MyListenerThatDoesNotShowDialogOnFail: System.Diagnostics.TraceListener
    {....
        public override void Fail(string message, string detailMessage)
        {// do soemthing UnitTest friendly here
        }
    }
    System.Diagnostics.Debug.Listeners.Clear();
    System.Diagnostics.Debug.Listeners.Add(new MyListenerThatDoesNotShowDialogOnFail());
