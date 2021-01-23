    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        IList<string> DateArray = new List<string>();
        IList<string> custArray = new List<string>();
        IList<string> payInBookArray = new List<string>();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            TextBox lblDate = (TextBox)gr.FindControl("txtDate");
            DateArray.Add(lblDate.Text);
            TextBox lblCustomers = (TextBox)gr.FindControl("txtCustomers");
            custArray.Add(lblCustomers.Text);
            TextBox lblPayInBookNo = (TextBox)gr.FindControl("txtPayingInBookNoOrDD");
            payInBookArray.Add(lblPayInBookNo.Text);
        }
        ExportToExcel(DateArray.ToArray(), custArray.ToArray(), payInBookArray.ToArray()); 
    }
