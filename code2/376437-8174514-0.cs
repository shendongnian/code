    using (Cbitmap = new Bitmap(sourceImage.Text))
    {
        Cbitmap.MakeTransparent(Color.White);
        System.IntPtr icH = Cbitmap.GetHicon();
        Icon ico = Icon.FromHandle(icH);
    }
    using (System.IO.FileStream f = new System.IO.FileStream(destinationFldr.Text + "\\image.ico", System.IO.FileMode.OpenOrCreate))
    {
        ico.Save(f);
    }
