    using(var db = new myDataContext())
    {
        var item = db.myTable.First(o => o.id == myId);
        item.Prop1 = newItem.Prop1;
        item.Prop2 = newItem.Prop2;
        // etc
    }
