    var listA = new List<string>();
    listA.Add("test");
    listA.Add("123");
    listA.Add("5.7");
    
    var listB = new List<Type>();
    listB.Add(typeof(string));
    listB.Add(typeof(int));
    listB.Add(typeof(float));
    
    var combined = listA.Zip(listB, (s, type) => (Value :s, Type:type));
    
    foreach (var item in combined)
    {
       try
       {
          Convert.ChangeType(item.Value, item.Type);
       }
       catch (Exception ex)
       {
          throw new InvalidOperationException($"Failed to cast value {item.Value} to {item.Type}",ex);
       }
    }
