private delegate void GUIInvokeMethodDelegate(Action @delegate);
/// <summary>
/// Invoke command with GUI thread. Usage: GUIInvoke(() => FormOrControl.Cmd());
/// </summary>
/// <param name="delegate">Command to execute in form: () => Cmd()</param>
public void GUIInvokeMethod(Action @delegate)
{
    // Check if we need to invoke as GUI thread
    if (this.InvokeRequired)
    {
        this.Invoke(new GUIInvokeMethodDelegate(GUIInvokeMethod), @delegate);
        return;
    }
    // Execute
    @delegate.Invoke();
}
public void DoThisAsGUI() 
{
    GUIInvokeMethod(() => 
    {
        // Something you want to do in GUI thread. 
    }); 
    // or
    GUIInvokeMethod(() => SomeMethodThatRequiresGUIThread());
}
