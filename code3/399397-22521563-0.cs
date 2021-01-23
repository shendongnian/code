    using (MemoryStream ms = new MemoryStream())
                    {
                        System.Drawing.Image myImg = System.Drawing.Image.FromFile(path);
                        //Calculate Horizontal and Vertical scale
                        float Hscale = ((float)96 / myImg.HorizontalResolution); 
                        float Vscale = ((float)96 / myImg.VerticalResolution );
                        myImg.Save(ms, myImg.RawFormat);  // Save your picture in a memory stream.
                        ms.Seek(0, SeekOrigin.Begin);
                        
                        Novacode.Image img = proposal.AddImage(ms); // Create image.
                        Picture pic1 = img.CreatePicture();     // Create picture.
                        
                        //Apply scale to height & width
                        pic1.Height = (int)(myImg.Height * Hscale);
                        pic1.Width = (int)(myImg.Width * Vscale);
                        a.InsertPicture(pic1, 0); // Insert picture into paragraph.
                    }
