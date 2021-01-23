    protected void btnDelete_Click(object sender, EventArgs e)
    {
    //Create String Collection to store 
    //IDs of records to be deleted 
      StringCollection idCollection = new StringCollection();
      string strID = string.Empty;
    
      //Loop through GridView rows to find checked rows 
       for (int i = 0; i < GridView1.Rows.Count; i++)
       {
        CheckBox chkDelete = (CheckBox)
           GridView1.Rows[i].Cells[0].FindControl("chkSelect");
                if (chkDelete != null)
                {
                    if (chkDelete.Checked)
                    {
                     strID = GridView1.Rows[i].Cells[1].Text;
                     idCollection.Add(strID);
                    }
                }
            }
    
            //Call the method to Delete records 
            DeleteMultipleRecords(idCollection);
    
            // rebind the GridView
            GridView1.DataBind();
        }
