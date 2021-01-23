    private void button1_Click(object sender, EventArgs e)
    {
        ICanDispose myObject1 = new ICanDispose();
        ICanNotDispose myObject2 = new ICanNotDispose();
        Type baseType = null;
    
        // Checking object 1 which does implement IDisposable.
        baseType = myObject1.GetType().GetInterface("IDisposable", true);
    
        if (baseType != null)
        {
            object baseObject = Activator.CreateInstance(myObject1.GetType());
            myObject1.GetType().InvokeMember("Dispose", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, baseObject, null);
        }
        else
        {
            MessageBox.Show("Object1 does not implemented the IDisposable Interface.");
        }
    
        // Checking object 2 which does not implement IDisposable.
        baseType = myObject2.GetType().GetInterface("IDisposable", true);
    
        if (baseType != null)
        {
            object baseObject = Activator.CreateInstance(myObject1.GetType());
            myObject2.GetType().InvokeMember("Dispose", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, baseObject, null);
        }
        else
        {
            MessageBox.Show("myObject2 does not implemented the IDisposable Interface.");
        }
    }
