        myBMP = new Bitmap(_xSize, _ySize, _xSize, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, _pImage);
        //_pImage is the pointer for our image
        //Change palatte of 8bit indexed BITMAP. Make r(i)=g(i)=b(i)
        ColorPalette _palette = myBMP.Palette;
        Color[] _entries = _palette.Entries;
        for (int i = 0; i < 256; i++)
        {
            Color b = new Color();
            b = Color.FromArgb((byte)i, (byte)i, (byte)i);
            _entries[i] = b;
        }
        myBMP.Palette = _palette;
        return myBMP;
