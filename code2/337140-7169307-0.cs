    [System.Web.Services.WebMethod()]
    public static void SaveDataFromClient(LONGFORM _lfFromClient)
    {
        DBDataContext _db = new DBDataContext();
        var _lfFromDB = _db.LONGFORMs.Where(l => l.ID == _lfFromClient.ID).FirstOrDefault();
        // Update all the properties of _lfFromDB here. For example:
        _lfFromDB.Property1 = _lfFromClient.Property1;
        _lfFromDB.Property2 = _lfFromClient.Property2;
        _db.SubmitChanges();
    }
