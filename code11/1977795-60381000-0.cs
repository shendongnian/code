    public class ObjectBaseCalls : ApiTestBase
    {
        static ReadOnlyCollection<string> AllTypes = new ReadOnlyCollection<string>(new List<string>() { "Value1", "Value 2" });
        [Test]
        public void ObjectCanBePostedAndGeted([ValueSource(nameof(AllTypes))] string type)
        {
            //My test
        }
    }
