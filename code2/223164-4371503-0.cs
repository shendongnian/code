    public class SomeOtherClassInSomeOtherDLL
    {
        public void DoSomethingWithData<T>(T dataSource)
        {
            // ...
            List<T> list = new List<T>();
            list.Add(dataSource);
            // ...
        }
    }
