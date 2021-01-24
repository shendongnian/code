    List<string> emailSplitterStrings = new List<string>();
    emailSplitterStrings.Add("as");
    emailSplitterStrings.Add(".");
    string content1 = "as Hey Cassie! as u know i am fine.reply soon";
    string regex = @"\b(?:" + string.Join("|", emailSplitterStrings.Select(Regex.Escape).ToArray()) + @")\b";
    List<string> split = Regex.Split(content1, regex).Select(x => x.Trim()).ToList();
    split.ForEach(Console.WriteLine);
