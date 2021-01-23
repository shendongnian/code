    private void LocationChange(Object obj, int first, int second) 
    { 
        // Logic that operates on the object regardless of its type goes here...
        // Although I'm not sure what that logic would be. :)
        // This check works since .NET 2.0 (I believe?) and lets you avoid 
        // an InvalidCastException if obj happens NOT to be a subclass of Control...
        if(obj is Control)
        {
            ((Control)obj).Location = new Point(first,second);
        }
    }
