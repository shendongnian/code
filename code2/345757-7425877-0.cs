    private void PrintMe()
    {
        var dlg = new PrintDialog();
        FixedPage fp = new FixedPage();
        fp.Height = 100;
        fp.Width = 100;
        fp.Children.Add(new System.Windows.Shapes.Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = System.Windows.Media.Brushes.Red
            });
        PageContent pc = new PageContent();
        pc.Child = fp;
        FixedDocument fd = new FixedDocument();
        fd.Pages.Add(pc);
        DocumentReference dr = new DocumentReference();
        dr.SetDocument(fd);
        FixedDocumentSequence fds = new FixedDocumentSequence();
        fds.References.Add(dr);            
        
        if (dlg.ShowDialog() == true)
        {
            dlg.PrintDocument(fds.DocumentPaginator, "test");
        }
    }
