    if (Regex.IsMatch(txtIssueDate.Text, "(((0|1)[0-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
    {
    		DateTime dt;
            args.IsValid = (DateTime.TryParseExact(args.Value, 
                                "dd/MM/yyyy", 
                                new CultureInfo("en-GB"), 
                                DateTimeStyles.None, 
                                out dt) || 
    		                DateTime.TryParseExact(args.Value, 
                                "d/MM/yyyy", 
                                new CultureInfo("en-GB"), 
                                DateTimeStyles.None, 
                                out dt) ||
                            DateTime.TryParseExact(args.Value, 
                                "yyyy/MM/dd", 
                                new CultureInfo("en-GB"), 
                                DateTimeStyles.None, 
                                out dt));
    }
    else
    {
        args.IsValid = false;
    	ScriptManager.RegisterStartupScript(UpdatePanel2, UpdatePanel2.GetType(), "myFunction", "alertInvalidDate();", true);
    }
