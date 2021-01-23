    public partial class ChildForm : Form
    { 
        private readonly ToolStrip parentToolStrip;
        public ChildForm(ToolStrip strip)
        {
            parentToolStrip = strip;
        }
    }
