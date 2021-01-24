    HashSet<string> names = new HashSet<strings>();
    
    for (int i = 0;i<=a.Length;i++)  
    {
    
     j = j++ % 3; // Will give 0,1,2,0,1,2,0,1,2... or use ranbd.Next(0,4)
     string forName = inty[j]; // Restricted to 0,1,2
     string newName = $"{forName}{a[j]}";
     if (! names.Contains(newName)
     {
      names.Add(newName);
      Console.WriteLine("Name: {newName}");
     }
     else 
     {
      Console.WriteLine("Ups!: {newName} already used!");
     }
    }
