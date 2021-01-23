    public delegate void NeedsUserDataEventHandler(object sender, NeedsUserDataEventArgs args);
    public class NeedsUserDataEventArgs : EventArgs
    {
        public UserData UserData { get; set; }
    }
    // In Control
    public event NeedsUserDataEventHandler NeedsUserData;
    public void OnNeedsUserData(NeedsUserDataEventArgs args)
    {
        NeedsUserDataEventHandler handler = NeedsUserData;
        if (handler != null) handler(this, args);
        // store your data somewhere here
    }
    // In Form
    public override void OnLoad(object sender, EventArgs args)
    {
        control.NeedsUserData += ControlNeedsUserData;
    }
    
    public override void OnClosed(object sender, EventArgs args)
    {
        control.NeedsUserData -= ControlNeedsUserData;
    }
    public void ControlNeedsUserData (object sender, NeedsUserDataEventArgs args)
    {
        args.UserData = // set whatever here
    }
