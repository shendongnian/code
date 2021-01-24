    List<string> fileList = Directory.GetFiles(path).ToList();
    StringBuilder sb = new StringBuilder();
    foreach (string file in fileList)
    {
        //Your business logic
        sb.Append($"Copied: {fileWithoutPath}" + Environment.Newline);
    }
    
        outputTextbox.Text = sb.ToString(); 
