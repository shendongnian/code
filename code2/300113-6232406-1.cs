    // note: replace yourList with the correct collection variable
    var distinctLetters = 
        yourList.Select(item => item.Name.Substring(0,1).ToUpper())
                .Distinct()
                .OrderBy(s => s);
    StringBuilder builder = new StringBuilder();
    foreach (string letter in distinctLetters)
    {
        // build your output by Appending to the StringBuilder instance 
        string text = string.Format("<h1 id='{0}'><span>{0}</span></h1>" + Environment.NewLine, letter);
        builder.Append(text);
    }
    string output = builder.ToString(); // use output as you see fit
