    foreach(var point in points)
    {
        var image = new System.Web.UI.WebControls.Image { ImageUrl = "/pin.jpg" };
        image.Style.Value = string.format("position:absolute;top:{0}px;left{1}px;display:block;width:30px; height:30px;", point.X, point.Y);
        imagePanel.Controls.Add(image);
    }
