    protected void DrugGridView_RowDataBound(object sender, GridViewRowEventArgs e)
           
    {
        // To check condition on integer value
        if (Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "Dosage")) == 50)
        {
          e.Row.BackColor = System.Drawing.Color.Cyan;
        }
    }
