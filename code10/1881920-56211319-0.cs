    public class DialogEventArgs : EventArgs
    {
        public string Selection { get; set; }
    }
    
    public delegate void DialogEventHandler(object sender, DialogEventArgs args);
