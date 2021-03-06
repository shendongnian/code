    public void LoadPixelDatabase()
            {
                // if we do not have a BackgroundImage yet
                if (this.Canvas.BackgroundImage == null)
                {
                    // to do: Show message
                    // bail
                    return;
                }
                // Set to true
                this.Analyzing = true;
                // Reset the Graph
                this.Graph.Visible = true;
                this.Graph.Value = 0;
                // Enable or disable controls
                UIEnable();
                // Create a Bitmap from the Source image
                Bitmap source = new Bitmap(this.Canvas.BackgroundImage);
                // Code To Lockbits
                BitmapData bitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, source.PixelFormat);
                IntPtr pointer = bitmapData.Scan0;
                int size = Math.Abs(bitmapData.Stride) * source.Height;
                byte[] pixels = new byte[size];
                Marshal.Copy(pointer, pixels, 0, size);
                // End Code To Lockbits
                // Marshal.Copy(pixels,0,pointer, size);
                source.UnlockBits(bitmapData);
                // test only
                int length = pixels.Length;
                // Set the Max for the grid, minus 10 just for comfort
                this.Graph.Maximum = source.Width * source.Height + 1000;
                // Create a new instance of a 'PixelDatabase' object.
                this.PixelDatabase = new PixelDatabase();
                // locals
                Color color = Color.FromArgb(0, 0, 0);
                int red = 0;
                int green = 0;
                int blue = 0;
                int alpha = 0;
                // variables to hold height and width
                int width = source.Width;
                int height = source.Height;
                int x = -1;
                int y = 0;
                
                // Iterating the pixel array, every 4th byte is a new pixel, much faster than GetPixel
                for (int a = 0; a < pixels.Length; a = a + 4)
                {
                     // increment the value for x
                    x++;
                    // every new column
                    if (x >= width)
                    {
                        // reset x
                        x = 0;
                        // Increment the value for y
                        y++;
                    }      
                    // Increment the value
                    this.Graph.Value++;
                    // get the values for r, g, and blue
                    blue = pixels[a];
                    green = pixels[a + 1];
                    red = pixels[a + 2];
                    alpha = pixels[a + 3];
                    
                    // create a color
                    color = Color.FromArgb(alpha, red, green, blue);
                    // Add this point
                    PixelInformation pixelInformation = this.PixelDatabase.AddPixel(color, x, y);
                }
                // Create a DirectBitmap
                this.DirectBitmap = new DirectBitmap(source.Width, source.Height);
                // Now we must copy over the Pixels from the PixelDatabase to the 
                // DirectBitmap
                if ((this.HasPixelDatabase) && (ListHelper.HasOneOrMoreItems(this.PixelDatabase.Pixels)))
                {
                    // iterate the pixels
                    foreach (PixelInformation pixel in this.PixelDatabase.Pixels)
                    {
                        // Set the pixel at this spot
                        DirectBitmap.SetPixel(pixel.X, pixel.Y, pixel.Color);
                    }
                }
                // Set to False
                this.Analyzing = false;
                // Set the value for the property 'ImageLoaded' to true
                this.ImageLoaded = true;
                // if the LineColor is not set
                if (this.LineColor == Color.Transparent)                
                {
                    // Set the LineColor
                    this.LineColor = SetLineColor();
                }
                // Enable controls now that we are done analyzing
                UIEnable();
            }
