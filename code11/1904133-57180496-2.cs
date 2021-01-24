    Dictionary<string, string> dict = new Dictionary<string, string>();
    dict.Add("key 1", "value 1");
    dict.Add("key 2", "value 2");
    dict.Add("key 3", "value 3");
    ...
    foreach (FieldCode field in document.MainDocumentPart.RootElement.Descendants<FieldCode>())
    {
        int indexEndName = field.Text.IndexOf("\\");
        string fieldName = field.Text.Substring(11, indexEndName - 11).Trim();
        ReplaceMergeFieldWithText(field, dict[fieldName]);
    }
