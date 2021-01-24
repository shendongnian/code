    using System.Drawing;
    using System.Windows.Forms;
    class SelectablePanel : Panel
    {
        const int ScrollSmallChange = 10;
        public SelectablePanel()
        {
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.UserMouse, true);
            TabStop = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var p = AutoScrollPosition;
            switch (keyData)
            {
                case Keys.Left:
                    AutoScrollPosition = new Point(-ScrollSmallChange - p.X, -p.Y);
                    return true;
                case Keys.Right:
                    AutoScrollPosition = new Point(ScrollSmallChange - p.X, -p.Y);
                    return true;
                case Keys.Up:
                    AutoScrollPosition = new Point(-p.X, -ScrollSmallChange - p.Y);
                    return true;
                case Keys.Down:
                    AutoScrollPosition = new Point(-p.X, ScrollSmallChange - p.Y);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
