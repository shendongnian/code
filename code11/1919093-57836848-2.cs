    List<string> elements = new List<string>();
    try
    {
        SqlParameter[] parms = new[]
        {
            new SqlParameter("mpid", myProtocolsId),
            new SqlParameter("elid", elementId)
        };
        elements = db.Database.SqlQuery<string>("p_MyProtocolsOverviewElementRemove @myProtocolsId = @mpid, @elementId = @elid", parms).ToList();
        return Json(elements);
    }
    catch (Exception e)
    {
        return Json(null);
    }
