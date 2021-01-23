    // open the file in a way so that we can read it line by line
    using (Stream fileStream = File.Open("path-to-file", FileMode.Open))
    using (StreamReader reader = new StreamReader(fileStream))
    {
        string line = null;
        do
        {
            // get the next line from the file
            line = reader.ReadLine();
            if (line == null)
            {
                // there are no more lines; break out of the loop
                break;
            }
            // split the line on each semicolon character
            string[] parts = line.Split(';');
            // now the array contains values as such:
            // "Name" in parts[0] 
            // "Surname" in parts[1] 
            // "Birthday" in parts[2] 
            // "Address" in parts[3] 
    
        } while (true);
    }
