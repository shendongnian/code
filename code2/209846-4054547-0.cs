    public class MyDropDown : ToolStripDropDownMenu {
        protected override Padding DefaultPadding {
            get { return Padding.Empty; }
        }
        public MyDropDown() {
            ShowImageMargin = ShowCheckMargin = false;
            RenderMode = ToolStripRenderMode.System;
            MaximumSize = new Size(200, 150);
        }
    }
    // adding items and calling Show() remains the same as in the question
