    public class Friend
    {
      public int id { get; set; }
    }
     List<Friend> lst = new List<Friend>();
                lst.Add(new Friend{ id = 1});
                lst.Add(new Friend { id = 1 });
                lst.Add(new Friend { id = 2 });
                lst.Add(new Friend { id = 3 });
                lst.Add(new Friend { id = 3 });
                lst.Add(new Friend { id = 4 });
    var data1 = lst.GroupBy(x => x.id).Where(x => x.Count() > 1).Select(x=>x.Key).ToList();
