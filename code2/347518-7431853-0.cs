    string messagestatus = String.Empty;
    
    var objStatus = DataBinder.Eval(e.Row.DataItem, "Status");
    
    if(objStatus != null)
    {
      messagestatus = objStatus.ToString();
    }
