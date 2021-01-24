    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        // (...)
        e.DrawBackground();
        using (var brush = new SolidBrush(this.ForeColor)) {
            e.Graphics.DrawString(this.GetItemText(this.Items[e.Index]), this.Font, brush, e.Bounds);
        }
        // (...)
    }
