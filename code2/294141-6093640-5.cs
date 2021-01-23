    List<Item> MyList = new List<Item>();
    Item MyItem = new Item();
    MyItem.Colour = "red";
    MyList.Add(MyItem);
    MyItem = new Item(); //<-- this is what you are missing
    MyItem.Colour = "blue";
    MyList.Add(MyItem);
