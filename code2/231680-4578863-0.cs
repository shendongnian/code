    string printingTaskFileName = Path.GetTempFileName(); // file in %temp%
    
    System.IO.FileStream printingTaskFile;
    System.IO.StreamWriter printingTaskStream;
    
    printingTaskFile = new System.IO.FileStream(printingTaskFileName, FileMode.Append);
    printingTaskStream = new System.IO.StreamWriter(printingTaskFile, System.Text.Encoding.Default);
    
    printingTaskStream.Write("some content here");
    printingTaskStream.Flush();
    printingTaskStream.Close();
    
    File.Copy(printingTaskFileName, "LPT1", true); // also can be \\127.0.0.1\PNT5 or smth like that
    File.Delete(printingTaskFileName);
