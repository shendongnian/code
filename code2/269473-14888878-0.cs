    private DateTime ConvertToDateTime(string strDateTime)
    {
    DateTime dtFinaldate; string sDateTime;
    try { dtFinaldate = Convert.ToDateTime(strDateTime); }
    catch (Exception e)
    {
    string[] sDate = strDateTime.Split('/');
    sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
    dtFinaldate = Convert.ToDateTime(sDateTime);
    }
    return dtFinaldate;
    }
