    SeparationColorSpace space = null;
    double X = 0, Y = 0, Width = 0, Height = 0;
    void ScanForSpecialColorspaceUsage(ContentScanner cs)
    {
        cs.MoveFirst();
        while (cs.MoveNext())
        {
            ContentObject content = cs.Current;
            if (content is CompositeObject)
            {
                ScanForSpecialColorspaceUsage(cs.ChildLevel);
            }
            else if (content is SetFillColorSpace _cs)
            {
                ColorSpace _space = cs.Contents.ContentContext.Resources.ColorSpaces[_cs.Name];
                space = _space as SeparationColorSpace;
            }
            else if (content is SetDeviceCMYKFillColor || content is SetDeviceGrayFillColor || content is SetDeviceRGBFillColor)
            {
                space = null;
            }
            else if (content is DrawRectangle _dr)
            {
                if (space != null)
                {
                    X = _dr.X;
                    Y = _dr.Y;
                    Width = _dr.Width;
                    Height = _dr.Height;
                }
            }
            else if (content is PaintPath _pp)
            {
                if (space != null && _pp.Filled && (X != 0 || Y != 0 || Width != 0 || Height != 0))
                {
                    String name = ((PdfName)((PdfArray)space.BaseDataObject)[1]).ToString();
                    Console.WriteLine("Filling rectangle at {0}, {1} with size {2}x{3} using {4}", X, Y, Width, Height, name);
                }
                X = 0;
                Y = 0;
                Width = 0;
                Height = 0;
            }
        }
    }
