                System.Drawing.Image img = System.Drawing.Image.FromFile(fileLocation);
                MemoryStream ms = new MemoryStream();
                if (picType == ".jpg")
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (picType == ".png")
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                string imgUrl = Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
                ms.Close();
                ms.Flush();
                //returns imgUrl to Json
