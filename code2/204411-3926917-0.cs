    MyObject obj = new MyObject();    
    
    List<MyObjectItem> items = new List<MyObjectItem>();    
    foreach (string line in text.Split) 
    { 
         // skip MyObject declaration int idx = line.IndexOf('.'); 
         string sub = line.Substring(idx); 
         if (sub.StartsWith("Name")) {
             obj.Name = sub.Substring("Name".Length + 3 /* (3 for the ' - ' part) */);
         }
         else
         {
              sub = sub.Substring("Items.".Length);
              int num = int.Parse(sub.Substring(0, sub.IndexOf('.'));
              sub = sub.Substring(sub.IndexOf('.' + 1);
              if (items.Count < num)
                  items.Add(new MyObjectItem());
              if (sub.StartsWith("Name"))
              {
                   items[num].Name = sub.SubString("Name".Length + 3);
              }
              else
              {
                   items[num].Total = sub.SubString("Total".Length + 3);
              }
         }
    }
    obj.Items = items;
