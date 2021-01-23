    DataTable dt = new DataTable();
    dt.Columns.Add("Question");
    dt.Columns.Add("Answer");
    DataRow dr = dt.NewRow();
    dr["Question"] = txtQuestion.Text;
    dr["Answer"] = txtAnswer.Text;
    dt.Rows.Add(dr);
    **DataRow dr = dt.NewRow();
    dr["Question"] = "2nd row";
    dr["Answer"] = "2nd row";
    dt.Rows.Add(dr);**
    dt.AcceptChanges();
    gvQnA.DataSource = dt;
    gvQnA.DataBind();
