    public bool ModifyFile(string filePath, List targetText, string replacementText)
    {
        if (!File.Exists(filePath)) return false;
        if (targetText == null || targetText.Count == 0) return false;
        if (string.IsNullOrEmpty(replacementText)) return false;
        string modifiedFileContent = string.Empty;
        bool hasContentChanged = false;
        Encoding sourceEndocing = null;
        using (StreamReader reader = File.OpenText(filePath))
        {
            sourceEndocing = reader.CurrentEncoding;
            string file = reader.ReadToEnd();
            foreach (string text in targetText)
                modifiedFileContent = file.Replace(text, replacementText);
            if (!file.Equals(modifiedFileContent))
                hasContentChanged = true;
        }
        if (!hasContentChanged) return false;
        using (StreamWriter writer = new StreamWriter(filePath, false, sourceEndocing))
        {
            writer.Write(modifiedFileContent);
        }
        return true;
    }
