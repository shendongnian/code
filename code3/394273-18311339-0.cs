    public class CustomTreeView : TreeView
    {
        private Rectangle buttonRect = new Rectangle(80, 2, 50, 26);
        private StringFormat stringFormat;
        public CustomTreeView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            ShowLines = false;
            FullRowSelect = true;
            ItemHeight = 30;
            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
        }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(this.ForeColor), e.Bounds, stringFormat);
            ButtonRenderer.DrawButton(e.Graphics, new Rectangle(e.Node.Bounds.Location + new Size(buttonRect.Location), buttonRect.Size), "btn", this.Font, true, (e.Node.Tag != null) ? (PushButtonState)e.Node.Tag : PushButtonState.Normal);
        }
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && (PushButtonState)e.Node.Tag == PushButtonState.Pressed)
            {
                e.Node.Tag = PushButtonState.Normal;
                MessageBox.Show(e.Node.Text + " clicked");
                // force redraw
                e.Node.Text = e.Node.Text;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            TreeNode tnode = GetNodeAt(e.Location);
            if (tnode == null) return;
            Rectangle btnRectAbsolute = new Rectangle(tnode.Bounds.Location + new Size(buttonRect.Location), buttonRect.Size);
            if (btnRectAbsolute.Contains(e.Location))
            {
                tnode.Tag = PushButtonState.Pressed;
                tnode.Text = tnode.Text;
            }
        }
    }
