    private static bool isLastIntervalNewerThanDB(string muiMethod)
    {
        using (var db = new IntLMPDB())
        {
            LastIntervalUpdated liRec = db.LastIntervalUpdateds.FirstOrDefault(rec => rec.method == muiMethod);
            if(liRec == null) throw new Exception(string.Format("Could NOT find LastIntervalUpdated record for muiMethod: {0}", muiMethod))
            return liRec.IsLastIntervalNewer;
        }
    }
