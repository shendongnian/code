    [WebMethod(EnableSession=true)]
    public string DealerLogin_Click(string name, string pass)
    {
        string g="";
        if (name == "w" && pass == "w")
        {
            Session["Public"]="pub";
            
            g= "window.location = '/secure/Default.aspx'";
        }
        
        return g;
    }
