    private void Grd_Detail_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
    {
        int i = 1;
        for (i = 0; i < Grd_Detail.RowCount; i++)
        {
            string s = Grd_Detail.GetRow(i).Cells["FN"].Value.ToString();
            if (s == "True")
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {                 
                    Janus.Windows.GridEX.GridEXFormatStyle rowcol = new GridEXFormatStyle();
                    rowcol.BackColor = Color.LightGreen;
                    Grd_Detail.GetRow(i).RowStyle = rowcol;
                }
            }
        }
    }
