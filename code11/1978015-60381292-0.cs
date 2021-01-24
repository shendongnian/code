    ConcurrentDictionary<string, string> compareDictionary = new ConcurrentDictionary<string, string>();
    
    foreach (var element in list1)
    {
       var item1Name= element.Name.ToString();
       var item1Id= element.ID.ToString();
       // If this element has already one correspondence, TryAdd will fail anyway
       if(compareDictionary.ContainsKey(item1Id)) continue; 
    
       var found = list2.FirstOrDefault(item => item1Name.Contains(item.item2Name.ToLower()));
       if(found != null)
       {
              compareDictionary.TryAdd(item1Id, item.item2Id);
       }
    }
