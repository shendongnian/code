    string contents = File.ReadAllText(filePath);
    contents = Regex.Replace(contents,
        "( " + column.Key + " )",
        " " + column.Value + " ");
    contents = Regex.Replace(contents,
        "(\\[\"" + column.Key + "\"\\])",
        "[\"" + column.Value + "\"]");
    File.WriteAllText(filePath, contents);
