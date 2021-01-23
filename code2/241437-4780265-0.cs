    public MyClass()
    {
        this.other = new SomeClass;
        other.AnotherEvent += SomeClass_AnotherEvent;
    }
    public event EventHandler MyEvent;
    private void SomeClass_AnotherEvent(object sender, EventArgs e)
    {
         if (MyEvent != null)
             MyEvent(this, e); // I think that it would be most logical, that you do not pass the sender
    }
