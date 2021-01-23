    for (int i = 0; i <= gvQuestion.Rows.Count - 1; i++)
    {
       RadioButtonList rdbChoice = (RadioButtonList)gvQuestion.Rows[i].FindControl("rdbChoice");
       string rd = rdbChoice.SelectedValue;
    }
