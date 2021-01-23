    public void btnCrop_Click(object sender, EventArgs e)
    {
      int _width = Convert.ToInt32(Width.Value);
      int _height = Convert.ToInt32(Height.Value);
      int _hori = Convert.ToInt32(Hori.Value);
      int _verti = Convert.ToInt32(Verti.Value);
      string ImageName = path;
    
      byte[] ImageToCrop = ReSize(path + ImageName, _width, _height, _hori, _verti);
      using (MemoryStream ms = new MemoryStream(ImageToCrop, 0, ImageToCrop.Length))
      {
        ms.Write(ImageToCrop, 0, ImageToCrop.Length);
        using(SD.Image CroppedImage = SD.Image.FromStream(ms, true))
        {
          string saveTo = path + "crop" + ImageName;
          CroppedImage.Save(SaveTo, CroppedImage.RawFormat);
          pnlCrop.Visible = false;
          pnlCropped.Visible = true;
          imgCropped.ImageUrl = "cropped image url" + ImageName;
        }
      }
    }
