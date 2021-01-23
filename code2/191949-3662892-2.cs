    public class Test
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Test(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
    public class TestFactory : IFactory<Test>
    {
        #region IFactory<Test> Members
        public Test CreateInstance()
        {
            return new Test("name", "type");
        }
        #endregion
        #region IFactory Members
        object IFactory.CreateInstance()
        {
            return this.CreateInstance();
        }
        #endregion
    }
    public class MyClass
    {
        // the Factory attribute on the first parameter indicates that the class TestFactory
        // should be used as a factory object to construct the argument for this method
        public string MyFunction([Factory(typeof(TestFactory))]Test obj)
        {
            if (obj == null)
                return null;
            else
                return obj.ToString();
        }
    }
