    public class MyTestClass : ILoadObjects<MyTestClass>
    {
        public List<MyTestClass> LoadBySearch()
        {
            List<MyTestClass> list = new List<MyTestClass>();
            list.Add(new MyTestClass());
            return list;
        }
        IList ILoadObjects.LoadBySearch()
        {
            return this.LoadBySearch();
        }
    }
