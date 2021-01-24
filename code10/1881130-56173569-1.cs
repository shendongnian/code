   public async Task FileWriteAsync(string text)
    {
      ReaderWriterLock locker = new ReaderWriterLock();
     try
       {
         locker.AcquireWriterLock(int.MaxValue); //You might wanna change timeout value 
         string file = @"uid.txt";
         using (FileStream sourceStream = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
         using (StreamWriter f = new StreamWriter(sourceStream))
         {
            await f.WriteLineAsync(text);
         }
        }
        finally
        {
            locker.ReleaseWriterLock();
        }
    }
    public void ExFile(int line)
    {
        var uid = Regex.Match(txt_ListUID.Lines[line], @"c_user=(.*?);").Groups[1].ToString().Trim();
        string text = uid + "|zxzxzx";
        _ = FileWriteAsync(text)
    }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.threading.readerwriterlock?view=netframework-4.8
