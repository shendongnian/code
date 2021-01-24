    public class MyCls
    {
        public List<TestData> MyData { get; set; }
        public MyCls(List<MY_SP_Result> data)
        {
            var testValues = data.Select(d => d.TEST_VALUE).Distinct();
            MyData = testValues.Select(tv => new TestData
            {
                TEST_VAL = tv,
                Data = data.Where(d => d.TEST_VALUE == tv).ToList()
            }).ToList();
        }
    }
