    public class WinformWrapper : WindowsFormsHost
    {
        private SimpleThing _mapControl;
        public WinformWrapper()
        {
            _mapControl = new SimpleThing();
            Child = _mapControl;
            Width = _mapControl.Width;
            Height = _mapControl.Height;
        }
    }
