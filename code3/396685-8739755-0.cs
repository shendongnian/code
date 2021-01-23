    public static void BeginInvokeIfRequired(this Control control, Action action)
    {
        if (control.IsHandleCreated)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
        else { 
             // in this case InvokeRequired might lie ! 
             throw new Exception ( "InvokeRequired is possibly wrong in this case" );
             }
    }
