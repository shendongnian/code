    var myLayoutWithAllMyNormalStuff = <make it>;
    var backgroundImage = new Image { ... };
    ContentPage page = new ContentPage {
    Content = new AbsoluteLayout {
     Children = {
      {backgroundImage, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All},
      {myLayoutWithAllMyNormalStuff, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.All}
      }
     }
    };
