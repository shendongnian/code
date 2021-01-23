    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip | 
                                       ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class TrackBarMenuItem : ToolStripControlHost
    {
        private TrackBar trackBar;
    
        public TrackBarMenuItem():base(new TrackBar())
        {
            this.trackBar = this.Control as TrackBar;
        }
    }
