    public string mMaxNo_Reg()
    {
         var reg = _db.Registrations.FromSqlRaw("EXECUTE SP_RandomNo_Reg");
         return reg.Reg_ID.ToString();
    }
