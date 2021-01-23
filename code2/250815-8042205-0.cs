    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBorder(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black),                    e.ConnectedArea);
        }
