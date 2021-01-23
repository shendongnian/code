    [WebMethod(EnableSession=true)]
    public string saveName(string name)
    {
        List<string> li;
        if (Session["Name"] == null)
        {
            Session["Name"] = name;
            return "Data saved successfully.";
    
        }
             
        else
        {
            Session["Name"] = Session["Name"] + "," + name;
            return "Data saved successfully.";
        }
    
      
    }
