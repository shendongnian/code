    private Int64 GetGameID(string gameFormatProductCode)
    {
        ModelCtn ctn = new ModelCtn();
        Game game = null;
        GameFormat gf = null;
    
        gf = (from t in ctn.GameFormat
            where t.GameFormatProductcode == gameFormatProductCode
            select t).FirstOrDefault();
    
        // Need to find GameID from Game table and return it.
        var gID = (from t in ctn.Game
                   where t.GameDataID == gf.GameDataID
                   select t.GameID).FirstOrDefault();
        return gID;
    
    }
    
