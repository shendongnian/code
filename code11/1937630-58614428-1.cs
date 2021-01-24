    private void WriteFile(string text)
        {
          // lock a generic object to ensure only one thread is accessing the following code block at a time
          lock (lockObj)
          {
              string filePath = Path.Combine(@"C:\ntlogs\",$"{DateTime.Now.ToString("yyyyMMdd HHmmss")}.txt");
              File.AppendAllText(filePath, text);
          }
