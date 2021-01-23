    public string PreviousSBU
    {
        get { return Convert.ToString(ViewState["PreviousSBU"] ?? string.Empty); }
        set { ViewState["PreviousSBU"] = value; }
    }
