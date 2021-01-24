    public class AdvancedTreeView : TreeView
    {
        private Bitmap openedIcon, closedIcon;
        public AdvancedTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            ShowLines = false;
            AlternateBackColor = BackColor;
            ArrowColor = SystemColors.WindowText;
        }
        public Color AlternateBackColor { get; set; }
        public Color ArrowColor { get; set; }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            // background
            Color backColor = (GetTopNodeIndex(e.Node) & 1) == 0 ? BackColor : AlternateBackColor;
            using (Brush b = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(b, new Rectangle(0, e.Bounds.Top, ClientSize.Width, e.Bounds.Height));
            }
            // icon
            if (e.Node.Nodes.Count > 0)
            {
                Image icon = GetIcon(e.Node.IsExpanded);
                e.Graphics.DrawImage(icon, e.Bounds.Left - icon.Width - 3, e.Bounds.Top);
            }
            // text (due to OwnerDrawText mode, indenting of e.Bounds will be correct)
            TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Bounds, ForeColor);
            // indicate selection (if not by backColor):
            if ((e.State & TreeNodeStates.Selected) != 0)
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
        }
        private int GetTopNodeIndex(TreeNode node)
        {
            while (node.Parent != null)
                node = node.Parent;
            return Nodes.IndexOf(node);
        }
        private Image GetIcon(bool nodeIsExpanded)
        {
            if (openedIcon == null)
                InitIcons();
            return nodeIsExpanded ? openedIcon : closedIcon;
        }
        private void InitIcons()
        {
            openedIcon = new Bitmap(16, 16);
            closedIcon = new Bitmap(16, 16);
            using (Brush b = new SolidBrush(ArrowColor))
            {
                using (Graphics g = Graphics.FromImage(openedIcon))
                    g.FillPolygon(b, new[] { new Point(0, 0), new Point(15, 0), new Point(8, 15), });
                using (Graphics g = Graphics.FromImage(closedIcon))
                    g.FillPolygon(b, new[] { new Point(0, 0), new Point(15, 8), new Point(0, 15), });
            }
        }
    }
