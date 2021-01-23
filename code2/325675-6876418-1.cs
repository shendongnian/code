    if (!Page.IsPostBack)
    {
        CanonicalNum = 0;
        Session["CanonicalNum"] = CanonicalNum;
    }
    else
    {
        CanonicalNum = (int)Session["CanonicalNum"];
    }
