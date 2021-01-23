                       System.Drawing.Image originalImage = //your image
    
                        //Create empty bitmap image of original size
    
                        Bitmap tempBmp = new Bitmap(originalImage.Width, originalImage.Height);
    
                        Graphics g = Graphics.FromImage(tempBmp);
    
                        //draw the original image on tempBmp
    
                        g.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height);
    
                        //dispose originalImage and Graphics so the file is now free
    
                        g.Dispose();
    
                        originalImage.Dispose();
    
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Convert Image to byte[]
                            tempBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            //dpgraphic.image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            byte[] imageBytes = ms.ToArray();
    
                            // Convert byte[] to Base64 String
                            string strImage = Convert.ToBase64String(imageBytes);
                            sb.AppendFormat(strImage);
                        }
