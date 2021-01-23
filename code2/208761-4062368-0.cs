    // Add some text to the paragraph
    paragraph.AddFormattedText("Hello, World!", TextFormat.Italic);
    
    // Add Bulletlist begin
    Style style = document.AddStyle("MyBulletList", "Normal");
    style.ParagraphFormat.LeftIndent = "0.5cm";
    string[] items = "Dodge|Nissan|Ford|Chevy".Split('|');
    for (int idx = 0; idx < items.Length; ++idx)
    {
      ListInfo listinfo = new ListInfo();
      listinfo.ContinuePreviousList = idx > 0;
      listinfo.ListType = ListType.BulletList1;
      paragraph = section.AddParagraph(items[idx]);
      paragraph.Style = "MyBulletList";
      paragraph.Format.ListInfo = listinfo;
    }
    // Add Bulletlist end
    
    return document;
