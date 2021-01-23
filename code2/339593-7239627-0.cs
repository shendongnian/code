    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Play Now"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gridCalls.Rows[index];
            string songname = row.Cells[5].Text; // second column in the sql server database
            StringBuilder str = new StringBuilder();
            str.Append("<object width='300px' height='300px'>");
            str.Append("<param name='autostart' value='true'>");
            str.Append("<param name='src' value='songs/" + songname + "'>");
            str.Append("<param name='autoplay' value='true'>");
            str.Append("<param name='controller' value='true'>");
            str.Append("<embed width='300px' height='300px' src='songs/" + songname + "' controller='true' autoplay='true' autostart='True' type='audio/wav' />");
            str.Append("</object>");
            LoadPlayer.Text = str.ToString();//here loadplayer is label control
        }
    }
