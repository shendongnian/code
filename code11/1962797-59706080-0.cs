    List<MyWrapper> ListOfFields = new List<MyWrapper>();
    foreach (FieldInfo field in this.GetType().GetFields())
    {
       var myItem = new MyWrapper(field, ListOfFields.Count);
       ListOfFields.Add(myItem);
    }
    class MyWrapper
    {
        public FieldInfo Field { get; private set; }
        public int Index { get; private set; }
        public MyWrapper(FieldInfo field, int index)
        {
            Field = field;
            Index = index;
        }
    }
