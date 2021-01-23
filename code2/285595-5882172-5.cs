       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> TimeZoneColl = TimeZoneInfo.GetSystemTimeZones();
                ddlTimeZones.DataSource = TimeZoneColl;
                ddlTimeZones.DataTextField = "StandardName";
                ddlTimeZones.DataValueField = "Id";
                ddlTimeZones.DataBind();
            }
            else
            {
                ShowTime();
            }
        }
        private void ShowTime()
        {
            DateTime thisTime = DateTime.Now;
            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(ddlTimeZones.SelectedValue);
            DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);
            lblShowTime.Text = tstTime.ToShortTimeString();
        
        }
    }
