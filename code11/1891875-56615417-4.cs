    var listA = new List<string> { "test", "123", "5.7" };
    var listB = new List<Type> { typeof(string), typeof(int), typeof(int) };
        
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
