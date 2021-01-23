    private void FixedDocument_Loaded(object sender, RoutedEventArgs e)
    {
        FixedDocument fixedDocument = sender as FixedDocument;
        MyUserControl myUserControl = new MyUserControl();
        FixedPage fixedPage = new FixedPage();
        fixedPage.Children.Add(myUserControl);
        PageContent pageContent = new PageContent();
        (pageContent as IAddChild).AddChild(fixedPage);
        fixedDocument.Pages.Add(pageContent);
    }
