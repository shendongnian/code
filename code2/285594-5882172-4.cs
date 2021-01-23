      System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> TimeZoneColl = TimeZoneInfo.GetSystemTimeZones();
            ddlTimeZones.DataSource = TimeZoneColl;
            ddlTimeZones.DataTextField = "StandardName";
            ddlTimeZones.DataValueField = "Id";
            ddlTimeZones.DataBind();
