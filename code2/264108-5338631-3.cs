    this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
    this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
    private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
    private void SetTabHeader(TabPage page, Color color)
    {
        TabColors[page] = color;
        tabControl1.Invalidate();
    }
    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        //e.DrawBackground();
        using (Brush br = new SolidBrush (TabColors[tabControl1.TabPages[e.Index]]))
        {
            e.Graphics.FillRectangle(br, e.Bounds);
            SizeF sz = e.Graphics.MeasureString(tabControl1.TabPages[e.Index].Text, e.Font);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);
            Rectangle rect = e.Bounds;
            rect.Offset(0, 1);
            rect.Inflate(0, -1);
            e.Graphics.DrawRectangle(Pens.DarkGray, rect);
            e.DrawFocusRectangle();
        }
    }
