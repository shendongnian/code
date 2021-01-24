    #region APRegisterRefNbr  
    [PXDBString(15)]
    [PXSelector(typeof(APRegister.refNbr))]
    [PXForeignReference(typeof(Field<APRegisterException.aPRegisterRefNbr>.IsRelatedTo<APRegister.refNbr>))]
    [PXUIField(DisplayName = "APRegisterRefNbr")]
    public virtual String APRegisterRefNbr  { get; set; }
    public abstract class aPRegisterRefNbr  : IBqlField { }
    #endregion
