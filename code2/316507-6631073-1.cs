    StringBuilder newFile = new StringBuilder();
    string[] file = File.ReadAllLines(@"file2path");
    foreach (string line in file)
    {
        if (!regex evaluation here!)
        {
            //append your number and increment counter here
            string temp = line.Replace(oldString, appendedString);
            newFile.Append(temp + "\r\n");
            continue;
        }
        newFile.Append(line + "\r\n");
    }
    File.WriteAllText(@""file2path", newFile.ToString());
