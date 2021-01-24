    var listOfDuplicates = new IEnumerable<YourObjectType>();
    foreach (var a in myList)
    {
         foreach (var b in myListb)
         {
             if (a.multival == b.multival && a.name != b.name)
                 listOfDuplicates.Add(a);
         }
    }
