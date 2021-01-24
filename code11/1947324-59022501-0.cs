    public class Grey64Menu
    {
        public Grey64Menu() : this(null) { }
        public Grey64Menu(ToolStrip menu) {
            if (menu != null) {
                ConfigureMenu(menu);
            }
        }
        public void ConfigureMenu(ToolStrip toolStrip)
        {
            toolStrip.Renderer = new MyMenuRenderer();
        }
    }
    public class MyMenuRenderer : ToolStripProfessionalRenderer
    {
        public MyMenuRenderer() : this(new Grey64ClrTable()) { }
        public MyMenuRenderer(ProfessionalColorTable colorTable) : base(colorTable) { }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.Item.ForeColor = Clr.White;
            base.OnRenderItemText(e);
        }
    }
    public class Grey64ClrTable : ProfessionalColorTable
    {
        // (...)
        // Fill the Image area: ImageMarginGradientMiddle is required for sub-items
        public override Color ImageMarginGradientMiddle => Clr.Grey64;
        public override Color ImageMarginGradientBegin => Clr.Grey64;
        public override Color ImageMarginGradientEnd => Clr.Grey64;
    }
