    private IDictionary<int, MyObject> _positionMap = new SortedList<int, MyObject>();
    private IDictionary<string, MyObject> _objectMap = new HashTable();
    public void Add(MyObject obj)
    {
         _positionMap.Add(obj.Location.X, obj);
         _objectMap.Add(obj.Id, obj);
    }
    public MyObject GetPositionById(string id)
    {
         return _objectMap[id].Location.X;
    }
    public IEnumerable<MyObject> SortedByX()
    {
         _positionMap.GetEnumerator();
    }
    public void Delete(string id)
    {
         var obj = _objectMap[id];
         _locationMap.Remove(obj.Location.X);
         _objectMap.Remove(id);
    }
