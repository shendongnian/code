    private void your_gridcontrol_double_click(object sender, EventArgs e)
    {
        GridHitInfo hit = your_gridview.CalcHitInfo((e as MouseEventArgs).Location);
        if (hit.InRow)
        {
        }
    }
