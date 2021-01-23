    XDocument xdXml;
    
    public MyWindow()
    {
    
        xdXml = XDocument.Load(@"C:\file.xml");
    
        InitializeComponent();
    
        DataContext = xdXml;
    
        xdXml.Changed += new EventHandler<XObjectChangeEventArgs>(XdXml_Changed);
    }
    
    
    private void XdXml_Changed(object sender, XObjectChangeEventArgs e)
    {
        xdXml.Save(@"C:\fichier.xml");
    }
    
    // finally, add this event:
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (((XElement)((FrameworkElement)sender).DataContext).Attribute("option").Value != ((TextBox)sender).Text)
        {
            ((XElement)((FrameworkElement)sender).DataContext).Attribute("option").Value = ((TextBox)sender).Text;
        }
    }
