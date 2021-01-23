            //Sample data from http://en.wikipedia.org/wiki/X_BitMap
            int Width = 16;
            int Height = 7;
            byte[] test_bits = { 0x13, 0x0, 0x15, 0x0, 0x93, 0xcd, 0x55, 0xa5, 0x93, 0xc5, 0x0, 0x80, 0x0, 0x60 };
            //Create our bitmap
            using (Bitmap B = new Bitmap(Width, Height))
            {
                //Will hold our byte as a string of bits
                string Bits = null;
                //Current X,Y of the painting process
                int X = 0;
                int Y = 0;
                //Loop through all of the bits
                for (int i = 0; i < test_bits.Length; i++)
                {
                    //Convert the current byte to a string of bits and pad with extra 0's if needed
                    Bits = Convert.ToString(test_bits[i], 2).PadLeft(8, '0');
                    //Bits are stored with the first pixel in the least signigicant bit so we need to work the string from right to left
                    for (int j = 7; j >=0; j--)
                    {
                        //Set the pixel's color based on whether the current bit is a 0 or 1
                        B.SetPixel(X, Y, Bits[j] == '0' ? Color.White : Color.Black);
                        //Incremement our X position
                        X += 1;
                    }
                    //If we're passed the right boundry, reset the X and move the Y to the next line
                    if (X >= Width)
                    {
                        X = 0;
                        Y += 1;
                    }
                }
                //Output the bitmap to the desktop
                B.Save(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "Output.bmp"), System.Drawing.Imaging.ImageFormat.Bmp);
            }
