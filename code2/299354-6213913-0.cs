      private DataTable Dt
        {
            set { ViewState.Add("Dt", value); }
            get { return (DataTable)ViewState["Dt"]; }
        }
...
    DataRow dr = Dt.NewRow();
    dr["Question"] = txtQuestion.Text;
    dr["Answer"] = txtAnswer.Text;
    Dt.Rows.Add(dr);
    Dt.AcceptChanges();
    
    gvQnA.DataSource = Dt;
    gvQnA.DataBind();
