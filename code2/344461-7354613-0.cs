    protected void OnSomeEvent( object sender, EventArgs e )
    {
        var trace = new StackTrace();
        var frames = trace.GetFrames();
        for ( int idx = 0; idx < frames.Length; idx++ )
        {
            MethodBase method;
            method = frames[idx].GetMethod();
            if ( method.ReflectedType == typeof(Derived) && method.IsConstructor )
            {
                return;
            }
        }
        /* Perform action */
    }
