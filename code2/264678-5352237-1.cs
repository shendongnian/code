    private int SelectedYear
    {
        get 
        { 
            object obj = Session["SelectedYear"];
            if (obj != null)
            {
                return int.Parse(obj.ToString()); 
            }
            else
            {
                return 0;
            }
        }
        set { Session["SelectedYear"] = value; }
    }
