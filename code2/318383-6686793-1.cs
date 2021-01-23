    ........
    public WhatEverType WhatEverData
    {
        get;
        set;
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataListWihtEvents.DataSource = WhatEverData;
            DataListWihtEvents.DataBind();
        }
        
    }
