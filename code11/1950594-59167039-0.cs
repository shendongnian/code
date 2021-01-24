    using (StreamWriter text= new StreamWriter(@"file.txt"))
    {
        text.WriteLine("The first line");
        text.WriteLine("This text is on the second line");
        text.WriteLine("And the third one.");
        text.Flush();
    }
    Console.WriteLine("The file has been successfully written.");
    
    // appending a text to the file
    using (StreamWriter sw = new StreamWriter(@"file.txt", true))
    {
        sw.WriteLine("An appended line");
        sw.Flush();
    }
    Console.WriteLine("A new line has been successfully appended into the file.");
    
    // printing the contents of the file
    Console.WriteLine("Printing file contents:");
    
    using (StreamReader sr = new StreamReader(@"file.txt"))
    {
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            Console.WriteLine(s);
        }
    }
    Console.ReadKey();
