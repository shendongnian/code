    string IcoFilename = "C:\\Junk\\Default.ico";
    using (System.IO.FileStream fs = new System.IO.FileStream(IcoFilename, System.IO.FileMode.Create))
    {
      this.Icon.Save(fs);
    }
