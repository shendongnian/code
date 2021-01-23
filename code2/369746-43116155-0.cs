    public class TableLayoutPanelEx : TableLayoutPanel
     {
        public TableLayoutPanelEx()
        {
            ControlAdded += OnControlAdded;            
        }
        private void OnControlAdded(object sender, ControlEventArgs args)
        {
            var control = args.Control as Label;
            if (control != null) { 
                control.TextAlign = ContentAlignment.MiddleLeft;                
                control.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left);
            }            
        }
    }
