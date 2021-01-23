    // Compose a string that consists of three lines.
    string myText= TextBox1.Text;
    
    // Write the string to a file.
    System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
    file.WriteLine(myText);
    
    file.Close();
