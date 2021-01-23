    List<string> list = new List<string>();
    System.IO.StreamReader file = new System.IO.StreamReader(filePath); 
    while(!file.EndOfStream)
    { 
      string line = file.ReadLine();
      list.add(line);
    } 
    Console.WriteLine("{0} lines read", list.Count);
    FlashText.Text = list[0];
