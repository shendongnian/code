    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        // (...)
        e.DrawBackground();
        using (var brush = new SolidBrush(this.ForeColor)) {
            e.Graphics.DrawString(this.Items[e.Index].ToString()), this.Font, brush, e.Bounds);
        }
        // (...)
    }
