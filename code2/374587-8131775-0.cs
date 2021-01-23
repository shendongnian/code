    public class Foo
    {
        public dynamic Data = new ExpandoObject();
        public Foo(params object[] args)
        {
            var dataDict = (IDictionary<string, object>)Data;
            foreach (var obj in args)
            {
                dataDict.Add(obj.ToString(), "..");
            }
        }
    }
