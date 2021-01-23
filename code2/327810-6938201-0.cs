    using System.IO;
    string tempFileName = Path.GetTempFileName();
    using (StreamWriter target = File.CreateText(tempFileName))
    {
        using(StreamReader source = file.OpenText("YourSourceFile.???"))
        {
            while (source.Peek() >= 0)
            {
                target.WriteLine(source.ReadLine().Insert(22, ";"));
            }
        }
    }
    File.Delete("YourSourceFile.???");
    File.Move(tempFileName, "YourSourceFile.???");
