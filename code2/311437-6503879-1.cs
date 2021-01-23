    var ser = new XmlSerializer(typeof(MyRoot));
    var obj = new MyRoot
    {
        Items = new MyListWrapper
        {
            Attribute1 = "hello",
            Attribute2 = "world",
            Items = new List<MyItem>
            {
                new MyItem { Id = 1},
                new MyItem { Id = 2},
                new MyItem { Id = 3}
            }
        }
    };
    ser.Serialize(Console.Out, obj);
