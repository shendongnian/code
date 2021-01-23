    List<string> list1 = new List<string>();
    list1.Add("Hello, World!");
    
    // This cast will fail, because the following line would then be legal:
    List<object> list2 = (List<object>)list1; 
    // ints are objects, but they are not strings!
    list2.Add(1);
