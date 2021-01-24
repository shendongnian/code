    [PXDBInt]
    [PXUIField(DisplayName = "Brand")]
    [PXSelector(
                typeof(Search<Branded.brandID>),
                SubstituteKey = typeof(Branded.brand))]
    public virtual int? UsrBrand { get; set; }
    public abstract class usrBrand : PX.Data.BQL.BqlInt.Field<usrBrand> { }
