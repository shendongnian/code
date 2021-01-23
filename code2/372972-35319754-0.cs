    public enum ControlSource
    {
        Programatic,
        ByKeyboard,
        ByMouse
    }
    public class AwareCheckBox : Checkbox
    {
        public AwareCheckBox()
                : base()
        {
            this.MouseDown += AwareCheckbox_MouseDown;
            this.KeyDown += AwareCheckbox_KeyDown;
        }
    
        private ControlSource controlSource = ControlSource.Programatic;
    
        void AwareCheckbox_KeyDown(object sender, KeyEventArgs e)
        {
            controlSource = ControlSource.ByKeyboard;
        }
    
        void AwareCheckbox_MouseDown(object sender, MouseEventArgs e)
        {
            controlSource = ControlSource.ByMouse;
        }
    
        public new event AwareControlEventHandler CheckedChanged;
        protected override void OnCheckedChanged(EventArgs e)
        {
            var handler = CheckedChanged;
            if (handler != null)
                handler(this, new AwareControlEventArgs(controlSource));
    
            controlSource = ControlSource.Programatic;
        }
    }
    
    public delegate void AwareControlEventHandler(object source, AwareControlEventArgs e);
    
    public class AwareControlEventArgs : EventArgs
    {
        public ControlSource Source { get; private set; }
    
        public AwareControlEventArgs(ControlSource s)
        {
            Source = s;
        }
    }
