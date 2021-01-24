    sqlQuerySpec.Parameters = new SqlParameterCollection()
    {
    	  new SqlParameter("@deviceId", deviceId.ToString("")),
    	  new SqlParameter("@startdate", DateTime.SpecifyKind(startdate, DateTimeKind.Utc)),
    	  new SqlParameter("@enddate", DateTime.SpecifyKind(enddate, DateTimeKind.Utc))
    };
