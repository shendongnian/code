    public int Position
    {
        get
        {
            int? position = null;
            if (ViewState["Position"] != null)
            {
                position = ViewState["Position"] as int?;
            }
            return position ?? 0;
        }
        set
        {
            ViewState["Position"] = value;
        }
    }
