    string FilePath = txtBoxInput.Text, Filepath2 = TextBox1.Text;
    int counter = 0;
    string line, line2;
    
    DirectoryInfo Folder = new DirectoryInfo(textboxPath.Text);
    var dir = @"D:\New folder\log";
    
    if (Folder.Exists)
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
    
    if (File.Exists(FilePath) && File.Exists(Filepath2))
    {   // Read the file and display it line by line.
        using (var file = File.OpenText(FilePath))
        {
            using (var file2 = File.OpenText(Filepath2))
            {
                while((line2 = file2.ReadLine()) != null)
                {
                    //YOU NEED TO CHECK IF FILE ALREADY EXISTS
                    // AND YOU WANT TO OVERWRITE OR CREATE NEW
                    //WITH SOME OTHER NAME
                    //---------------------------------------CREATE NEW FILE FOR
                    //---------------------------------------EACH LINE IN file2
                    using (var dest = File.AppendText(Path.Combine(dir, line2 + ".txt")))
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Contains(line2))
                                dest.WriteLine("LineNo : " + 
                                    counter.ToString() + " : " + line + "<br />");
                            counter++;
                        }
                        //IF THE SECOND FILE ONLY CONTAINS 1 LINE THEN YOU
                        //DON'T NEED THIS.
                        //we need to go to begning of first file
                        file.BaseStream.Seek(0, SeekOrigin.Begin);
                        counter = 0;
                    }
                }
            }
        }
    }
