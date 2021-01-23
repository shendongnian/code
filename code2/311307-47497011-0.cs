    //Neat generic trick to invoke anything on a windows form control class  
    //https://stackoverflow.com/questions/2367718/automating-the-invokerequired-code-pattern
    //Use like this:
    //object1.InvokeIfRequired(c => { c.Visible = true; });
    //object1.InvokeIfRequired(c => { c.Text = "ABC"; });
    //object1.InvokeIfRequired(c => 
    //  { 
    //      c.Text = "ABC";
    //      c.Visible = true; 
    //  }
    //);
    public static void InvokeIfRequired<T>(this T c, Action<T> action) where T : Control
    {
        if (c.InvokeRequired)
        {
            c.Invoke(new Action(() => action(c)));
        }
        else
        {
            action(c);
        }
    }
