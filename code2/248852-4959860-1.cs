public void InvokeMyEvent(string param1)
{
    MyEventDelegate myEventDelegate = MyEvent;
    if (myEventDelegate != null)
        myEventDelegate(this, param1);
}
