    // replace a given line in a given text file with a given replacement line
    private void ReplaceLine(string fileName, int lineNrToBeReplaced, string newLine)
    {
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        {
            // the memory writer will hold the read and modified lines
            using (StreamWriter memWriter = new StreamWriter(new MemoryStream()))
            {
                // this is for reading lines from the source file
                using (StreamReader fileReader = new StreamReader(new IsolatedStorageFileStream(fileName, System.IO.FileMode.Open, isf)))
                {
                    int lineCount = 0;
                    // iterate file and read lines
                    while (!fileReader.EndOfStream)
                    {
                        string line = fileReader.ReadLine();
                        // check if this is the line which should be replaced; check is done by line 
                        // number but could also be based on content
                        if (lineCount++ != lineNrToBeReplaced)
                        {
                            // just copy line from file
                            memWriter.WriteLine(line);
                        }
                        else
                        {
                            // replace line from file
                            memWriter.WriteLine(newLine);
                        }
                    }
                }
                memWriter.Flush();
                memWriter.BaseStream.Position = 0;
                // re-create file and save all lines from memory to this file
                using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(fileName, System.IO.FileMode.Create, isf))
                {
                    memWriter.BaseStream.CopyTo(fileStream);
                }
            }
        }
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        ReplaceLine("test.txt", 1, "status1 read good");
    }
