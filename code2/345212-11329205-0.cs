     barray = GetImage(filepath);
                            if (barray != null)
                            {
                                ms.Write(barray, 0, barray.Length - 1);
                                imageBitmap = CreateThumbnail(ms, new Size(PreviewImageWidth, PreviewImageHeight));
                                bm = ImageUtils.IBitmapImageToBitmap(imageBitmap);
    
                               // m_CurrentImageID = Convert.ToInt32(lstPic.ToList()[index].Id);
                                PictureBox ib = ((PictureBox)this.imagePanel.Controls[(nIndex * 2) + 1]);
                                ib.Image = bm;
    }
    
     private byte[] GetImage(string FilePath)
            {
                byte[] barray;
    
                if (File.Exists(FilePath))
                {
                    FileInfo _fileInfo = new FileInfo(FilePath);
                    long _NumBytes = _fileInfo.Length;
                    FileStream _FStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    BinaryReader _BinaryReader = new BinaryReader(_FStream);
                    barray = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes));
                    _FStream.Flush();
                    _FStream.Dispose();
                    return barray;
                }
                else
                {
                    return null;
                }
    
            }
    
    public IBitmapImage CreateThumbnail(Stream stream, Size size)
            {
                IBitmapImage imageBitmap;
                ImageInfo ii;
                IImage image;
                ImagingFactory factory = new ImagingFactoryClass();
                try
                {
    
                    factory.CreateImageFromStream(new StreamOnFile(stream), out image);
                    image.GetImageInfo(out ii);
                    factory.CreateBitmapFromImage(image, (uint)size.Width, (uint)size.Height, ii.PixelFormat, InterpolationHint.InterpolationHintDefault, out imageBitmap);
                    return imageBitmap;
    
    
                }
                catch (Exception ex)
                {
                    CreateLogFiles Err = new CreateLogFiles();
                    Err.ErrorLog(ex.Message);
                    return null;
                }
                finally
                {
                    imageBitmap = null;
                    image = null;
                    factory = null;
                }
            }
