    class CustomToolStripProfessionalRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripProfessionalRenderer()
            : base(new CustomProfessionalColorTable())
        {
    
        }
    
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Don't draw a border
        }
    }
