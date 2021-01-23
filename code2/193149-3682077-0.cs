    public class MyCustomCollection
    {
        List<MyObject> _list = new List<MyObject>();
        public string this[string name]
        {
            get { return _list.Single(o => o.Name == name)
                              .Select(o => o.Description);
        }
        public string this[int id]
        {
            get { return _list.Single(o => o.Id == id).Select(o => o.Description);
        }
    }
