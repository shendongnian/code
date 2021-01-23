    DataTable dt = DataAccess.GetHRInfo(userId);
    int activeValue;
    // by default false
    bool optIsActiveYes = false;
    if (dt.Rows[0]["Active"] != null 
        && Int32.TryParse(dt.Rows[0]["Active"].ToString(), out activeValue))
    {
        optIsActiveYes = activeValue == 1;
    }
