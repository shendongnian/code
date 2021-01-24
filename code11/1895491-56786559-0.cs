    string FilePath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), @"Template\MailContent.txt");
    string FileText = File.ReadAllText(FilePath);
    string UserName = "Brijesh";
    string Result = "Passed";
     
     var replacements = new ListDictionary{ {"{UserName}", UserName }, {"{Result}", Result }}
    
    foreach (DictionaryEntry replacement in replacements)
        {
            FileText = FileText.Replace($"{replacement.Key}", $"{replacement.Value}");
        }
