    //a generic method
    private PAC PAC_GetPAC(Func<PAC, bool> predicate)
    {
       return _gam.PAC.Where(predicate).FirstOrDefault();
    }
    
    public PAC PAC_GetPACById(long id)
    {
       return PAC_GetPAC(p => p.ID == id);
    }
    
    public PAC PAC_GetByCodiPac(string codiPac)
    {
       return PAC_GetPAC(p => pac.CODI_PAC == codiPac);
    }
