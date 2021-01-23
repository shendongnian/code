    string s = The input text from test.txt
    
    string[] bags = s.Split(new string[] {"EOS"}, StringSplitOptions.None);
    
    // This will give you an array of strings (minus the EOS field)
    // Then write the files...
    
    System.IO.File.WriteAllText(bag1 path, bags[0] + "EOS");  < -- Add this you need the EOS at the end field the field
    
    System.IO.File.WriteAllText(bag2 path, bags[1]);
    
    System.IO.File.WriteAllText(bag3 path, bags[3]);
    
    or somthing more efficient like...
    
    foreach(string bag in bags)
    {
      ... write the bag file here
    }
