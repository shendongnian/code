     public string Main(Bitmap image)
            {
                 string str = "";
                try
                {
                   
                    int width = image.Width;
                    int height = image.Height;
    
                    Graphics offScreenBufferGraphics;
                    Metafile m;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (offScreenBufferGraphics = Graphics.FromImage(image))
                        {
                            IntPtr deviceContextHandle = offScreenBufferGraphics.GetHdc();
                            m = new Metafile(
                            stream,
                            deviceContextHandle,
                            new RectangleF(0, 0, width, height),
                            MetafileFrameUnit.Pixel,
                            EmfType.EmfPlusOnly);
                            offScreenBufferGraphics.ReleaseHdc();
                        }
                    }
    
                    using (Graphics g = Graphics.FromImage(m))
                    {
                        // Set everything to high quality and Draw image
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        MetafileHeader metafileHeader = m.GetMetafileHeader();
                        g.ScaleTransform(
                          metafileHeader.DpiX / g.DpiX,
                          metafileHeader.DpiY / g.DpiY);
                        g.PageUnit = GraphicsUnit.Pixel;
                        g.SetClip(new RectangleF(0, 0, width, height));
                        Point ulCorner = new Point(0, 0);
                        g.DrawImage(image, 0, 0, width, height);
    
    
                    }
    
                    // Get a handle to the metafile
                    IntPtr iptrMetafileHandle = m.GetHenhmetafile();
    
                    // Export metafile to an image file
                    CopyEnhMetaFile(iptrMetafileHandle, @"c:\\Ginko-Bilobatest1234.wmf");
                    str = "wmf image successfully generated.";
                }
                catch (Exception ex)
                {
                    str = ex.InnerException + ex.Message;
                }
                return str;
                // Delete the metafile from memory
                // DeleteEnhMetaFile(iptrMetafileHandle);
            }
    
     
