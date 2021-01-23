    CommaDelimitedStringCollection list = new CommaDelimitedStringCollection();
    
    list.AddRange(new string[] { "Huey", "Dewey" });
    list.Add("Louie");
    //list.Add(",");
    
    string s = list.ToString(); //Huey,Dewey,Louie
