    private void FixedDocument_Loaded(object sender, RoutedEventArgs e)
    {
        FixedDocument fixedDocument = sender as FixedDocument;
        MyUserControl myUserControl = new MyUserControl();
        myUserControl.HorizontalAlignment = HorizontalAlignment.Center;
        myUserControl.VerticalAlignment = VerticalAlignment.Center;
        Grid grid = new Grid();            
        grid.Children.Add(myUserControl);
            
        FixedPage fixedPage = new FixedPage();
        fixedPage.Children.Add(grid);
        Binding widthBinding = new Binding("ActualWidth");
        widthBinding.Source = fixedPage;
        Binding heightBinding = new Binding("ActualHeight");
        heightBinding.Source = fixedPage;
        grid.SetBinding(Grid.WidthProperty, widthBinding);
        grid.SetBinding(Grid.HeightProperty, heightBinding);
        PageContent pageContent = new PageContent();
        (pageContent as IAddChild).AddChild(fixedPage);
        fixedDocument.Pages.Add(pageContent);
    }
