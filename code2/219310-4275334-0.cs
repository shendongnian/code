    Link link = new Link(@"c:\temp\dev\ClearAllIcon.png");
    var newButton = new Button();
    newButton.Content = "bloberific";
    var style = (Style)FindResource("ImageButton");
    ImageButton.SetImage(newButton, link.IconSource);
    MainStack.Children.Add(newButton);
