      var GatepassIDs = defaultView.ToTable().AsEnumerable().Select(r => r.Field<string>("GatePassID")).ToArray<string>();
    
      StringBuilder sb = new StringBuilder();
      sb.Append("<script>");
      sb.Append("var yourGatePassIDArray= new Array;");
      foreach(string str in GatepassIDs)
      {
        sb.Append("yourGatePassIDArray.push('" + str + "');");
      }
      sb.Append("</script>");
    
      ClientScript.RegisterStartupScript(this.GetType(), "YourArrayScript", sb.ToString());
