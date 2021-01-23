    [DllExport]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    static Object CreateDotNetObject([MarshalAs(UnmanagedType.LPStr)] String text)
    {
       try
       {
          var testFileName = Path.Combine(Path.GetTempPath(), "VbaTestFile.txt");
          if (!File.Exists(testFileName))
             File.WriteAllText(testFileName, "abc Äö ~éêè @dkfjf", Encoding.UTF8);
    
          using (var writer = File.AppendText(testFileName))
             writer.WriteLine(text);
    
          return new StreamReader(testFileName);
       }
       catch (Exception ex)
       {
          MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return null;
       }
    }
