    static void Main(string[] args)
    {
        var demoTxt = new FileInfo("C:\\demo.txt");
        demoTxt.Attributes |= FileAttributes.ReadOnly;
        WriteAllText("should succeed");
        try
        {
            demoTxt.Attributes |= FileAttributes.ReadOnly;
            WriteAllText("should fail");
        }
        catch (UnauthorizedAccessException uae)
        {
            Debug.WriteLine(uae.ToString());
        }
    }
    static void WriteAllText(string text)
    {
        // This is the button labeled "Save" in the program.
        //
        File.WriteAllText("C:\\demo.txt", text);
    }
