    foreach (string line in lines)
    {
        string[] columns= line.Split('\t');
        if (columns.Length != 9) // Or how many colums the file should have.
            continue; // Line probably not valid
    
        // Now access all the columns of the line by using 
        // columns[0], columns[1], etc
    }
