     #region UsrBrand
        [PXDBString(100)]
        [PXUIField(DisplayName="Brand")]
        //red
        [PXSelector(
            typeof(Search<Branded.brand>),new Type[]
             {
                typeof(Branded.brandID),
                typeof(Branded.brand))]
             }
        public virtual string UsrBrand { get; set; }
        public abstract class usrBrand : PX.Data.BQL.BqlString.Field<usrBrand> { }
        #endregion
