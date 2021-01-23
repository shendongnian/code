    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> TimeZoneColl = TimeZoneInfo.GetSystemTimeZones();
            DropDownList2.DataSource = TimeZoneColl;
            DropDownList2.DataTextField = "DisplayName";
            DropDownList2.DataValueField = "Id";     
            DropDownList2.DataBind();
        }
    }
