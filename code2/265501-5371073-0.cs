     double GrdTotal = 0;
        protected void grdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double price = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));
            GrdTotal += price;
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPrice = (Label)e.Row.FindControl("UnitPrice");
                lblTotalPrice.Text = GrdTotal.ToString();
            }
        }
