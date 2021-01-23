    ms.Write(ImageToCrop, 0, ImageToCrop.Length);
    using(SD.Image CroppedImage = SD.Image.FromStream(ms, true))
    {
      string saveTo = path + "crop" + ImageName;
      CroppedImage.Save(SaveTo, CroppedImage.RawFormat);
      pnlCrop.Visible = false;
      pnlCropped.Visible = true;
      imgCropped.ImageUrl = "cropped image url" + ImageName;
    }
