    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip |
                                           ToolStripItemDesignerAvailability.ContextMenuStrip | 
                                           ToolStripItemDesignerAvailability.StatusStrip)]
        public class ComboStripItem : ToolStripControlHost
        {
            private ComboBox combo;
    
            public ComboStripItem()
                : base(new ComboBox())
            {
                this.combo = this.Control as ComboBox;
            }
    
            // Add properties, events etc. you want to expose...
        }
