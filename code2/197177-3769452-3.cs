    private void button1_Click(object sender, EventArgs e)
    {
        ICanDispose myObject1 = new ICanDispose();
        ICanNotDispose myObject2 = new ICanNotDispose();
    
        // Checking object 1 which does implement IDisposable.
        if (myObject1.GetType().GetInterface("IDisposable", true) != null)
        {
            myObject1.GetType().InvokeMember(
                "Dispose", 
                System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, 
                null, 
                Activator.CreateInstance(myObject1.GetType()), 
                null);
        }
    
        // Checking object 2 which does not implement IDisposable.    
        if (myObject2.GetType().GetInterface("IDisposable", true) != null)
        {
            myObject2.GetType().InvokeMember(
                "Dispose", 
                System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, 
                null, 
                Activator.CreateInstance(myObject2.GetType()), 
                null);
        }
    }
