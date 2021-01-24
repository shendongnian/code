    private void Search() {
        _hits.Clear();
        tbTotal.Visible = false;
        if (tbSearch.Text.Length < 3) return;
        Searchy(tbSearch.Text);
        if (_hits.Count == 0) return;
        foreach (var hit in _hits) {
            dgvEvents.Rows[hit.RowNum].Cells[2].Style = new DataGridViewCellStyle {
                BackColor = hit.color == Color.Empty ? ext.myColor : hit.color,
                ForeColor = invert(BackColor)
            };
        }
        panelPaint.Invalidate();
        extrabuttons(true);
        tbTotal.Text = allhits().Count.ToString();
    }
    private void panelPaint_Paint(object sender, PaintEventArgs e)
    {
        if (_hits.Count == 0) return;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        foreach (var hit in _hits) {
            PaintPanel(hit, e.Graphics);
        }
    }
    private void PaintPanel(Hit hit, Graphics g)
    {
        using (Pen myPen = new Pen(hit.color == Color.Empty ? ext.myColor : hit.color, 1)) {
            float percent = ((float)hit.RowNum / dgvEvents.Rows.Count) * (float)panelPaint.Height;
            g.DrawLine(myPen, 1, percent, panelPaint.Width, percent);
        }
    }
