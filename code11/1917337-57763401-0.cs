    //Do your validation as you wish, this was just an example.
    var image = UIDevice.CurrentDevice.CheckSystemVersion(10, 0)
                    ? UIImage.FromBundle("facescan.jpg")
                    : UIImage.FromBundle("fingerprint.jpg");
    //The Control property is an UIButtton
    Control?.SetImage(image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal), UIControlState.Normal);
