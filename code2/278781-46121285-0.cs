    var oldVisibility = myBorder.Visibility;
    myBorder.Visibility = Visibility.Visible;
    myBorder.UpdateLayout();
    var height = myBorder.RenderSize.Height;
    myBorder.Visibility = oldVisibility;
