     for (int i = 0; i <= gvQuestion.Rows.Count - 1; i++)
     {
          if (gvQuestion.Rows[i].RowType == DataControlRowType.DataRow)
          {
               RadioButtonList rd1 = (RadioButtonList)gvQuestion.Rows[0].FindControl("rdbChoice");
               string rd = rd1.SelectedValue.ToString();
          }
     }
