    DataTable  dataTable = gridView.DataSource as DataTable;
    
    if (dataTable != null)
    {
    
      DataRow dr = dt.NewRow();
      dr["Question"] = txtQuestion.Text;
      dr["Answer"] = txtAnswer.Text;
      dt.Rows.Add(dr);
      dt.AcceptChanges();
    
      gvQnA.DataSource = dt;
      gvQnA.DataBind();
    }
