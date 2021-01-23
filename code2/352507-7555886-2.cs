    using (StreamReader tsr = new StreamReader(targetFilePath))
    {
        using (StreamWriter tsw = File.CreateText(targetFilePath+"_temp"))
        {
             string currentLine;
             while((currentLine = tsr.ReadLine()) != null)
             {
                 if(currentLine.StartsWith("A long time ago, in a far far away galaxy ..."))
                 {
                        tsw.WriteLine(currentLine);
                 }
             }
        }
    }
    File.Delete(targetFilePath);
    File.Move(targetFilePath+"_temp",targetFilePath);
