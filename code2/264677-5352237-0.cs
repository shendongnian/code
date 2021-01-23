    private int SelectedYear
    {
        get 
        { 
            object obj = Session["SelectedYear"];
            if (obj != null)
            {
                return int.Parse(Session["SelectedYear"].ToString()); 
            }
            else
            {
                return 0;
            }
        }
        set { Session["SelectedYear"] = value; }
    }
