        static private void GenerateGifImage(FileStream fileStream, int OutputWidth, int OutputHeight)
        {            
            // MemoryStream InputStream = new MemoryStream();
            FileStream InputStream = fileStream;
            // fileStream.Write(InputStream.GetBuffer(), 0, (int)InputStream.Position);
            // InputStream.Seek(0, SeekOrigin.Begin);
            Image InputImage = Image.FromStream(InputStream, true, false);
            // this will invalidate the underlying image object in InputImage but the class properties 
            // will still accessible until the object is disposed
            InputStream.Seek(0, SeekOrigin.Begin);
            ImageInfo imageInfo = RegisteredDecoders.GetImageInfo(InputStream);
            InputStream.Seek(0, SeekOrigin.Begin);
            GifDecoder gifDecoder = new GifDecoder();
            int count = gifDecoder.GetFrameCount(InputStream);
            GifFrameCollection gifFrameCollection = new GifFrameCollection();
            gifFrameCollection.Height = OutputHeight;
            gifFrameCollection.Width = OutputWidth;
            double ratio;
            if (InputImage.Height > InputImage.Width)
            {
                ratio = (double)OutputHeight / (double)InputImage.Height;
            }
            else
            {
                ratio = (double)OutputWidth / (double)InputImage.Width;
            }
            for (int i = 0; i < count; i++)
            {
                GifFrame frame = gifDecoder.Frames[i];
                Rectangle rectangle = new Rectangle(Point.Empty, frame.Image.Size);
                int newframeWidth = frame.Image.Width;
                int newframeHeight = frame.Image.Height;
                if (newframeWidth > OutputWidth || newframeHeight > OutputHeight)
                {
                    newframeWidth = (int)(frame.Image.Width * ratio);
                    newframeHeight = (int)(frame.Image.Height * ratio);
                }
                // account for erratic rounding, seems illogical but has happened earlier when using floats instead of doubles 
                if (newframeWidth > OutputWidth)
                {
                    newframeWidth = OutputWidth;
                }
                if (newframeHeight > OutputHeight)
                {
                    newframeHeight = OutputHeight;
                }
                Size size = new Size(newframeWidth, newframeHeight);
                // only resize if we have a measureable dimension
                if (size.Width > 0 && size.Height > 0)
                {
                    //ResampleCommand resampleCommand = new ResampleCommand(rectangle, size, ResampleMethod.);
                    AtalaImage atalaImage = frame.Image;
                    if (newframeWidth != frame.Image.Width || newframeHeight != frame.Image.Height)
                    {
                        CropCommand command = new CropCommand(new Rectangle(new Point(0, 0), size));
                        atalaImage = command.Apply(frame.Image).Image;
                    }
                    // AtalaImage atalaImage = frame.Image;
                    Point point = new Point((int)(frame.Location.X), (int)(frame.Location.Y));
                    // Point point = new Point((int)(frame.Location.X), (int)(frame.Location.Y));
                    gifFrameCollection.Add(new GifFrame(atalaImage, point, frame.DelayTime, frame.Interlaced, frame.FrameDisposal, frame.TransparentIndex, frame.UseLocalPalette));
                }
            }
            FileStream saveStream = new FileStream("resized.gif", FileMode.Create, FileAccess.Write, FileShare.Write);
            GifEncoder gifSave = new GifEncoder();
            gifSave.Save(saveStream, gifFrameCollection, null);
            saveStream.Close();
        }
