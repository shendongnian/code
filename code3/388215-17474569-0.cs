       byte[] rgbValues1 = new byte[4];
        
                                System.Drawing.Imaging.BitmapData bpData =
                                bm.LockBits(new Rectangle(0,0,bm.Width,bm.Height),System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                bm.PixelFormat);
        
                            int thisPixel = ptStart.X * 4 + ptStart.Y * bpData.Stride;
        
                            IntPtr px = bpData.Scan0 + thisPixel;
        
                            System.Runtime.InteropServices.Marshal.Copy(px, rgbValues1, 0, rgbValues1.Length);
        
        
                            rgbValues1[0] = (byte)(255);//blue channel
        
                            rgbValues1[1] = (byte)(0);//green channel
        
                            rgbValues1[2] = (byte)(0);//red channel
        
                            rgbValues1[3] = (byte)(127)//should be alpha channel
        
                            System.Runtime.InteropServices.Marshal.Copy(rgbValues1, 0, px, 4);
        
                            bm.UnlockBits(bpData);
