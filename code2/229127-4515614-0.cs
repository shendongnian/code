     protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        if (GridView2.SelectedIndex == 0)
        {
            webspace.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text;
            Bandwidth.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[2].Text;
            Email.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[3].Text;
            FTP.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[4].Text;
            Subdomain.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[5].Text;
            mysql.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[6].Text;
            
        }
