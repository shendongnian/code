    //Read a file,
    string[] lines = File.ReadAllLines(@"c:\temp\nodes.txt");
    
    // process it line by line,
    foreach(string line in lines){
      // split the line on colon
      string[] bits = line.Split(':');
      // take the bit after the colon and parse it to an integer
      int x = int.Parse(bits[1]);
      //push it into the list
      myList.Push(x);
    }
