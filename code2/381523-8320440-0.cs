    public List<int> previouslyClickedOptions{
        get {
           if (Session["prevClicked"] == null)
               Session["prevClicked"] = new List<int>();
           return (List<int>)Session["prevClicked"];
        }
    }
