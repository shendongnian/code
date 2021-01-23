public void homework()
{
    string filePath = @"E:\test.txt";
    string stringToAdd = "test_new";
    IList<string> readLines = new List<string>();
    // Read the file line-wise into List
    using(var streamReader = new StreamReader(filePath, Encoding.Default))
    {
        while(!streamReader.EndOfStream)
        {
            readLines.Add(streamReader.ReadLine());
        }
    }
    
    // If list contains stringToAdd then remove all its instances from the list; otherwise add stringToAdd to the list
    if (readLines.Contains(stringToAdd))
    {
        readLines.Remove(stringToAdd);
    }
    else
    {
        readLines.Add(stringToAdd);
    }
    // Write the modified list to the file
    using (var streamWriter = new StreamWriter(filePath, false, Encoding.Default))
    {
       foreach(string line in readLines)
       {
           streamWriter.WriteLine(line);
       }
    }
}
