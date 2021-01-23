    try
    {
     object result = processClass.InvokeMethod("Create", methodArgs);
    }
    catch (Exception e)
    {  
        //use Console.Write(e.Message); from Console Application 
        //and use MessageBox.Show(e.Message); from WindowsForm and WPF Application
    }
