    List<string> list = new List<string>();
    list.Add("lots of strings");
    
    //If you want to print all the strings you can do:
    foreach(string str in list)
       Console.WriteLine(str);
    
    //If you want to modify each string in the list, make each lower case for example, 
    // you can do. this is working by using the index of the elements in the list:
    for(int i = 0; i < list.Count; i++)
       list[i] = list[i].ToLower();
