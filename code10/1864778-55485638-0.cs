     OrderDetailsGridView.DataSource = reader;
     OrderDetailsGridView.DataBind();
     cnn2.Close();
     GetTotal();//Code added to your textbox
    public void GetTotal()
        {
            double Total = 0;
            foreach (GridViewRow r in OrderDetailsGridView.Rows)
            {
                Total = Total + double.Parse(r.Cells[4].Text); // double check if this is the orderline price
            }
            YourTextBox.Text = Total.ToString();
        }
