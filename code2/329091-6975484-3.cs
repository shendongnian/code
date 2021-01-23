    protected DataTable dtColors
    {
        get
        {
            if (Session["fabrics-dtColors"] == null)
                Session["fabrics-dtColors"] = FetchDataTable("SELECT DISTINCT Color FROM X ORDER BY Color");
            return (DataTable)Session["fabrics-dtColors"]; 
        }
    }
    
    protected DataTable dtStyles
    {
        get
        {
            if (Session["fabrics-dtStyles"] == null)
                Session["fabrics-dtStyles"] = FetchDataTable("SELECT DISTINCT Style FROM X ORDER BY Style");
            return (DataTable)Session["fabrics-dtStyles"]; 
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cblColors.DataSource = dtColors;
            cblColors.DataBind();
    
            cblStyles.DataSource = dtStyles;
            cblStyles.DataBind();
        }
    }
    
    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        string colors = String.Empty;
        string styles = String.Empty;
        string sql = "SELECT * FROM [X]";
                
        if (cblColors.SelectedIndex > -1)
        {
            for (int i = 0; i < cblColors.Items.Count; i++)
            {
                if (cblColors.Items[i].Selected)
                {
                    colors += String.Format("'{0}',", dtColors.Rows[i][0]);
                }
            }
    
            colors = colors.TrimEnd(',');
        }
    
        if (cblStyles.SelectedIndex > -1)
        {
            for (int i = 0; i < cblStyles.Items.Count; i++)
            {
                if (cblStyles.Items[i].Selected)
                {
                    styles += String.Format("'{0}',", dtStyles.Rows[i][0]);
                }
            }
    
            styles = styles.TrimEnd(',');
        }
    
        if (styles.Length > 0 && colors.Length > 0)
            sql += String.Format(" WHERE [Style] IN ({0}) AND [Color] IN ({1})", styles, colors);
        else if (styles.Length > 0)
            sql += String.Format(" WHERE [Style] IN ({0})", styles);
        else if (colors.Length > 0)
            sql += String.Format(" WHERE [Color] IN ({0})", colors);
    
        GetSearchResults(sql);
    }
