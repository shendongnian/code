    // Read the file as one string.
    System.IO.StreamReader myFile =
       new System.IO.StreamReader("c:\\test.txt");
    string myString = myFile.ReadToEnd();
    
    myFile.Close();
    
    // Display the file contents.
    Console.WriteLine(myString);
    // Suspend the screen.
    Console.ReadLine();
