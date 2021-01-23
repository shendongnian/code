    string[] ss = {"1","1","1"};
    
    var myList = new List<string>();
    var duplicates = new List<string>();
    
    foreach (var s in ss)
    {
       if (!myList.Contains(s))
          myList.Add(s);
       else
          duplicates.Add(s);
    }
    
    // show list without duplicates 
    foreach (var s in myList)
       Console.WriteLine(s);
                
    // show duplicates list
    foreach (var s in duplicates)
       Console.WriteLine(s);
