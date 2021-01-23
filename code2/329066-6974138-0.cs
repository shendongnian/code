    System.IO.StreamReader file = new System.IO.StreamReader(@"c:\myfile.txt");
    while((line = file.ReadLine()) != null)
    {
     // do something with the line
    }
    file.Close();
