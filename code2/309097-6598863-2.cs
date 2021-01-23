    private UserControl ReadMenuObj(ScreeningArea area)
    {
        bool isCanvasAdded = false;
        int initSide = 0;
        string myStream;
        string mystrName;
        string nameCounter;
        string lData = null;
        UserControl localUC = new UserControl();
        XDocument xmlFile = new XDocument();
        Storyboard localSB = new Storyboard();
        Canvas XAMLWindowCanvas = new Canvas();
        IEnumerable<XElement> elementList;
        StreamReader menuReader;
        MemoryStream stream = null;
        xmlFile = XDocument.Load(VideoMenuSystem.DataPath + "\\" + area.CurrentItem.ItemName + ".xaml");
        menuReader = new StreamReader(VideoMenuSystem.DataPath + "\\" + area.CurrentItem.ItemName + ".xaml");
        myStream = menuReader.ReadToEnd();
        TextToFile(myStream, VideoMenuSystem.DataPath + "\\" + "xamlFile.txt", false);
        elementList = xmlFile.Root.Descendants();
        myStoryboard = new Storyboard();
        foreach (XElement el in elementList)
        {
            mystrName = el.Name.LocalName;
            switch (mystrName)
            {
                case "Storyboard":
                    lData = el.ToString();
                    TextToFile(lData, VideoMenuSystem.DataPath + "\\" + "storyBoardFile.txt", true);
                    stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(lData));
                    localSB = XamlReader.Load(stream) as Storyboard;
                    for (int i = 0; i < localSB.Children.Count; i++)
                    {
                        Timeline tm = (Timeline)localSB.Children.ElementAt(i);
                        myStoryboard.Children.Add(tm);
                    }
                    //myStoryboard.Children.Add(localSB);
                    break;
                case "Canvas":
                    lData = el.ToString();
                    XAMLWindowCanvas = new Canvas();
                    if (lData != null)
                    {
                        TextToFile(lData, VideoMenuSystem.DataPath + "\\" + "xamlFile2.txt", true);
                        stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(lData));
                        DependencyObject rootObject = XamlReader.Load(stream) as DependencyObject;
                        XAMLWindowCanvas = rootObject as Canvas;
                        //XAMLWindowCanvas.Children.Add(XamlReader.Load(stream) as UIElement);
                        foreach (ScreeningArea sa in Screens)
                        {
                            if (sa == area)
                            {
                                initSide = menuSize.Width + screenSeparator;
                                break;
                            }
                        }
                        XAMLWindowCanvas.Margin = new Thickness(left, 0, 0, 0);
                        //XAMLWindowCanvas.Loaded += new RoutedEventHandler(fireAnimation);
                        XAMLWindowCanvas.MouseDown += new MouseButtonEventHandler(fireAnimation);
                        localUC.Content = XAMLWindowCanvas;
                        int cnvConut = XAMLWindowCanvas.Children.Count;
                        left += initSide;
                    }
                    isCanvasAdded = true;
                    break;
            }
            if (isCanvasAdded)
                break;
        }
        menuStoryboardList.Add(myStoryboard);
        nameCounter = DateTime.Now.Ticks.ToString();
        String myNameCounter = nameCounter.Substring(nameCounter.Length - 10);
        localUC.Resources.Add( "SB_" + myNameCounter, myStoryboard);
        Canvas cnv = (Canvas)localUC.FindName("Combo_3");
        Storyboard storyboard = (Storyboard)localUC.Resources["CombonAnim"];
        return localUC;
    }
 
