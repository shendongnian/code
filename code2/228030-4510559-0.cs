    public void DoStuff()
    {
        int index = 0;
        StackFrame frame = new StackFrame(index++);
        while (this.GetType().Name.Equals(frame.GetMethod().DeclaringType.Name))
        {
            frame = new StackFrame(index++);
        }
        //...
    }
