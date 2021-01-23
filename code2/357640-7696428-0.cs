    private void dg_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
        System.Windows.Forms.DataGridViewCellStyle boldStyle = new System.Windows.Forms.DataGridViewCellStyle();
        boldStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
        dg.Rows[e.RowIndex].DefaultCellStyle = boldStyle;
    }
    private void dg_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
        System.Windows.Forms.DataGridViewCellStyle norStyle = new System.Windows.Forms.DataGridViewCellStyle();
        norStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
        dg.Rows[e.RowIndex].DefaultCellStyle = norStyle;
    }
