            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                   
                    if (myIsolatedStorage.FileExists(fileName))
                    {
                        myIsolatedStorage.DeleteFile(fileName);
                    }
                    IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(fileName);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.SetSource(imageStream);
                    MessageBox.Show("ImageStream :"+ imageStream.Length.ToString());
                    WriteableBitmap wb = new WriteableBitmap(bitmap);
             // reeducing less than 524288 byte array
                    long compImageSize = 524288;
                    long originalsize =  wb.ToByteArray().Length;
                    if ((Convert.ToInt32(originalsize)) > compImageSize)
                    {
                        WriteableBitmap wBitmap = new WriteableBitmap(bitmap);
                        int height = wBitmap.PixelHeight;
                        int width = wBitmap.PixelWidth;
                        while ((Convert.ToInt32(originalsize)) > compImageSize)
                        {
                            //  wb.Resize(Convert.ToInt32( wb.PixelWidth / 2), Convert.ToInt32(wb.PixelHeight / 2), WriteableBitmapExtensions.Interpolation.Bilinear);
                            // data = ChangeDimension(bitmap, Convert.ToInt32(bitmap.PixelWidth / 2), Convert.ToInt32(bitmap.PixelHeight / 2));
                            using (MemoryStream stream = new MemoryStream())
                            {
                                height = Convert.ToInt32(wBitmap.PixelHeight / 2);
                                width = Convert.ToInt32(wBitmap.PixelWidth / 2);
                                wBitmap.SaveJpeg(stream, width, height, 0, 100);
                                stream.Seek(0, SeekOrigin.Begin);
                                wBitmap.SetSource(stream);
                            }
                            originalsize = wBitmap.ToByteArray().Length;
                        }
                
                        wb.SaveJpeg(fileStream, width, height, 0, 100);
                    }
                    else
                    {
                        wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                    }
                    fileStream.Close();          
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
