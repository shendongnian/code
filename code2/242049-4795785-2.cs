    RichTextBox rich = new RichTextBox();
    Console.Write(rich.Rtf);
    
    String[] words = { "Européen", "Apple", "Carrot", "Touché", "Résumé", "A Européen eating an apple while writing his Résumé, Touché!" };
    foreach (String word in words)
    {
        rich.Text = word;
        Int32 offset = rich.Rtf.IndexOf(@"\f0\fs17") + 9;// oops, forgot the space padding ;-)
        Int32 len = rich.Rtf.LastIndexOf(@"\par") - offset;
        Console.WriteLine("{0,-15} : {1}", word, rich.Rtf.Substring(offset, len));
    }
