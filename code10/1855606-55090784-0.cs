class A
{
    public event EventHandler MyEvent;
}
abstract class B : MarshalByRefObject
{
    public B()
    {
        MySecondEvent += InvokeSubClass;
    }
    private void InvokeSubClass(object o, EventArgs e)
    {
        var eventDelegate = (MulticastDelegate)subClass.GetType()
            .GetField("MyEvent", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .GetValue(subClass);
        if (eventDelegate != null)
        {
            foreach (var handler in eventDelegate.GetInvocationList())
            {
                handler.Method.Invoke(handler.Target, new object[] { subClass, e });
            }
        }
    }
    public event EventHandler MySecondEvent;
    private A subClass;
}
