    PrintDialog pd = new PrintDialog();
    pd.ShowDialog();
    FlowDocument doc = new FlowDocument();
    Paragraph ph = new Paragraph();
    StackPanel sp = new StackPanel();
    BlockUIContainer buc = new BlockUIContainer(sp);
    ph.Inlines.Add(new Bold(new Run("TODO\n")));
    
    foreach (CheckBox cb in box.Items)
    {
        int value = Convert.ToInt32("0x6F", 16);
        string stringValue = Char.ConvertFromUtf32(value);
        CheckBox bt = new CheckBox();
        bt.IsChecked = false;
        bt.Content = cb.Content;
        //ph.Inlines.Add(new Run(bt + " " + cb.Content.ToString()));
        sp.Children.Add(bt);
     }
     doc.Blocks.Add(buc);
     doc.Name = "FlowDoc";
     doc.Blocks.Add(ph);
     IDocumentPaginatorSource idpSource = doc;
     pd.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing."); 
