    public class ObjectBaseCalls : ApiTestBase
    {
        static ReadOnlyCollection<string> AllTypes = new ReadOnlyCollection<string>(new List<string>() { "Value1", "Value 2" });
        [TestCaseSource(nameof(AllTypes))]
        public void ObjectCanBePostedAndGeted(string type)
        {
            //My test
        }
    }
