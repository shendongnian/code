GridViewRow thisRow = e.Row;
Label currentValue = thisRow.Cells[2].FindControl("lblSubCategory") as Label;
GridViewRow prevRow = gvEscalationLinks.Rows[e.Row.RowIndex - 1];
Label previousValue = prevRow.Cells[2].FindControl("lblSubCategory") as Label;
if (previousValue.Text != currentValue.Text)...
However, I had a lot of trouble actually getting the colors to alternate properly and ended up with something that just feels kludged to me:
protected void gvEscalationLinks_RowDataBound(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        GridViewRow thisRow = e.Row;
        Label currentValue = thisRow.Cells[2].FindControl("lblSubCategory") as Label;
        if (e.Row.DataItemIndex == 0)
        {
            e.Row.Cells[1].BackColor = Color.AliceBlue;
            Session["color"] = "AliceBlue";
            return;
        }
        GridViewRow prevRow = gvEscalationLinks.Rows[e.Row.RowIndex - 1];
        Label previousValue = prevRow.Cells[2].FindControl("lblSubCategory") as Label;
        if (previousValue.Text != currentValue.Text)
        {
            if ( Session["color"].ToString() == "AliceBlue" )
            {
                e.Row.Cells[1].BackColor = Color.White;
                Session["color"] = "White";
            }
            else
            {
                e.Row.Cells[1].BackColor = Color.AliceBlue;
                Session["color"] = "AliceBlue";
            }
        }
        else
        {
            if (Session["color"].ToString() == "AliceBlue")
            {
                e.Row.Cells[1].BackColor = Color.AliceBlue;
            }
            else
            {
                e.Row.Cells[1].BackColor = Color.White;
            }
        }
    }
}
