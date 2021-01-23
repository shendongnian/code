    /* Set the options you want */
    tidy.Options.DocType = DocType.Strict;
    tidy.Options.DropFontTags = true;
    tidy.Options.LogicalEmphasis = true;
    tidy.Options.Xhtml = true;
    tidy.Options.XmlOut = true;
    tidy.Options.MakeClean = true;
    tidy.Options.TidyMark = false;
    
    /* Declare the parameters that is needed */
    TidyMessageCollection tmc = new TidyMessageCollection();
    MemoryStream input = new MemoryStream();
    MemoryStream output = new MemoryStream();
    
    byte[] byteArray = Encoding.UTF8.GetBytes("Put your HTML here...");
    input.Write(byteArray, 0 , byteArray.Length);
    input.Position = 0;
    tidy.Parse(input, output, tmc);
    
    string result = Encoding.UTF8.GetString(output.ToArray());
