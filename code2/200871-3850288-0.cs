    // Attempt to write to the file
    try
    {
        // Compose a string that consists of three lines.
        string myText= TextBox1.Text;
        
        // Write the string to a file.
        using(System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt"));
        {
            file.WriteLine(lines);
        }
    }
    catch(IOException exception) //Catch and display exception
    {
         MessageBox.Show(exception.Message());
    }
