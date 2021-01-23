    // Compose a string that consists of three lines.
    string lines = "First line.\r\nSecond line.\r\nThird line.";
    
    // Write the string to a file.
    System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
    file.WriteLine(lines);
    
    file.Close();
