            // Rasterise the pencil tool
            // Assume it is square
            // Check the pixel to be set is witin the bounds of the layer
            // Set the tool size rect to the locate on of the point to be painted
            m_toolArea.Location = position;
            // Get the area to be painted
            Rectangle areaToPaint = new Rectangle();
            areaToPaint = Rectangle.Intersect(layer.GetRectangle(), m_toolArea);
            Bitmap bmp;
            BitmapData data = bmp.LockBits(new Rectangle(areaToPaint.Right, areaToPaint.Top), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = data.Stride;
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                // Check this is not a null area
                if (!areaToPaint.IsEmpty)
                {
                    // Go through the draw area and set the pixels as they should be
                    for (int y = areaToPaint.Top; y < areaToPaint.Bottom; y++)
                    {
                        for (int x = areaToPaint.Left; x < areaToPaint.Right; x++)
                        {
                            layer.GetBitmap().SetPixel(x, y, m_colour);
                            ptr[(x * 3) + y * stride] = m_colour.B;
                            ptr[(x * 3) + y * stride + 1] = m_colour.G;
                            ptr[(x * 3) + y * stride + 2] = m_colour.R;
                        }
                    }
                }
            }
            bmp.UnlockBits(data);
        }
