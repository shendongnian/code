     public class Item
     {
         public string Name;
         public List<string> Keywords = new List<string>();
         public int Num;
     }
        
     List<Item> items = new List<Item>();
     var items2 = items.SelectMany(p => p.Keywords.Select(q => new { Keyword = q, Item = p })).ToLookup(p => p.Keyword, p => p.Item);
