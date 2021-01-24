    #region UsrComb 
    [PXDBString]
    [Combs.List]        
    [PXUIField(DisplayName = "Comb")]
    public virtual string UsrComb { get; set; }
    public abstract class usrComb : PX.Data.BQL.BqlBool.Field<usrComb> { }
    #endregion
    
    
    #region UsrText 
    [PXDBString]
    [PXUIField(DisplayName = "Text")]
    //pxdefault is required if you have a PXUIRequired attribute.
    [PXDefault(PersistingCheck = PXPersistingCheck.Nothing)]
    [PXUIRequired(typeof(Where<usrComb, Equal<Combs.other>>))]
    [PXUIVisible(typeof(Where<usrComb, Equal<Combs.other>>))]
    [PXUIEnabled(typeof(Where<usrComb, Equal<Combs.other>>))]
    public virtual String UsrText { get; set; }
    public abstract class usrText : PX.Data.BQL.BqlString.Field<usrText> { }
    #endregion
