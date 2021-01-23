    public class FooToBarResult
    {
        public string FooId { get; set; }
        public int BarId { get; set; }
    }
    IList<BlockToComponentResult> result = session
           .CreateSQLQuery(@"SELECT bar_id as BarId, id as FooId FROM `foo`")
           .SetResultTransformer(Transformers.AliasToBean<FooToBarResult>())
           .List<FooToBarResult>();
