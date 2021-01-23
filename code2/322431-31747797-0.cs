    foreach (SdtElement sdt in mainPart.Document.Descendants<SdtElement>())
    {
    SdtAlias alias = sdt.Descendants<SdtAlias>().FirstOrDefault();
    if (alias != null)
     {
      string sdtTitle = alias.Val.Value;
      Text t = sdt.Descendants<Text>().First();
      t.Text = "test";
     }
    }
