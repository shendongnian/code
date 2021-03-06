    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (dataGridView1.IsCurrentCellDirty)
        {
            if (!string.IsNullOrEmpty(e.ErrorText))
            {
                GraphicsContainer container = e.Graphics.BeginContainer();
                e.Graphics.TranslateTransform(18,0);
                e.Paint(this.ClientRectangle, DataGridViewPaintParts.ErrorIcon);
                e.Graphics.EndContainer(container);
                e.Handled = true;
            }
        }
    }
