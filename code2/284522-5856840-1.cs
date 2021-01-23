    List<MyEnt> list = new List<MyEnt>();
    foreach(DataRow dr in table.Rows)
    {
      MyEnt obj = new MyEnt();
    obj.Load(dr.ItemArray);
    list.Add(obj);
    }
