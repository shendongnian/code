                    System.Drawing.Bitmap tiffImage;
                    using(BinaryWriter  baseWriter = new BinaryWriter(new MemoryStream()))
                    {
                        baseWriter.Write(tiffData);
                        baseWriter.BaseStream.Position = 0;
                        tiffImage = new System.Drawing.Bitmap(baseWriter.BaseStream);
                    }
                   
                    MemoryStream jpgStream = new MemoryStream();
    
                    tiffImage.Save(jpgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    jpgStream.Position = 0;
                    using (BinaryReader br = new BinaryReader(jpgStream))
                    {
                        context.Response.BinaryWrite(br.ReadBytes(jpgStream.Length));
                    }
