    private string ImagePath { get { return ViewState["ImageUrl"].ToString(); } }
    drawing.Image image = drawing.Image.FromStream(
        new MemoryStream(
            System.IO.File.ReadAllBytes(
                HttpContext.Current.Server.MapPath(this.ImagePath)
            )
        )
    );
    cropedImage.Save(path);
