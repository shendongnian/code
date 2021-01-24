    public class Test : IBqlTable
    {
        #region UsrATC
        [PXDBString(10)]
        [PXUIField(DisplayName = "ATC")]
        [PXSelector(typeof(Search<withhildingtax.atc>),
                    typeof(withhildingtax.Atcdescription),
                    typeof(withhildingtax.Taxrate))]
        public virtual string UsrATC { get; set; }
        public abstract class usrATC : PX.Data.BQL.BqlString.Field<usrATC> { }
        #endregion
        #region UsrWTAXPercentage
        [PXDBDecimal]
        [PXUIField(DisplayName = "WTaxPercentage")]
        [PXDefault(typeof(Search<withhildingtax.Taxrate, Where<withhildingtax.atc, Equal<Current<Test.usrATC>>>>))]
        [PXSelector(typeof(Search<withhildingtax.Taxrate, Where<withhildingtax.atc, Equal<Current<Test.usrATC>>>>))]
        public virtual Decimal? UsrWTAXPercentage { get; set; }
        public abstract class usrWTAXPercentage : PX.Data.BQL.BqlDecimal.Field<usrWTAXPercentage> { }
        #endregion
    }
    public class TestGraph : PXGraph<TestGraph>
    {
        protected virtual void Test_UsrATC_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e)
        {
            if (e.Row is Test row)
            {
                sender.SetDefaultExt<Test.usrWTAXPercentage>(e.Row);
            }
        }
    }
