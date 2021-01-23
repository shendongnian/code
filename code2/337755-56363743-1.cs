public static bool SafeInvoke( this Control control, MethodInvoker method )
{
    if( control != null && ! control.IsDisposed && control.IsHandleCreated && control.FindForm().IsHandleCreated )
    {
        if( control.InvokeRequired )
        {
            control.Invoke( method );
        }
        else
        {
            method();
        }
        return true;
    }
    return false;
}
