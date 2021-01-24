    string statusVal = null;
    if (ViewState["stat"] != null && ViewState["stat"].ToString() != "0")
    {
        statusVal = ViewState["stat"].ToString();
    }
    cmd.Parameters.AddWithValue("statusVal", statusVal);  //<= Now this string variable contains comma separated list box items values.
    
