    //Read all the text in the file
    string lines = File.ReadAllText(path);
    
    //Output the original text
    Console.Write(lines);
    //Add your new line
    lines += "This line is added by Visual Studio" + Environment.NewLine;
    
    //Write the now updated text to the file
    File.WriteAllText(path, lines);
    
    //Output the new text
    Console.Write(lines);
