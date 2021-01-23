    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        string recNUnits = e.Row.Cells[4].Text;
        recomN.Text = recNUnits;
        if(!String.IsNullOrEmpty(e.Row.Cells[4].Text))
        {
            recommend = decimal.Parse(e.Row.Cells[4].Text);
        }
        calcNtoApply();
     } 
