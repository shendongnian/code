      static void Main(string[] args)
            { Path string Outputpath = @"C:\Users\MDASARATHAN\Desktop\TX_HARDIN_10-01-2016_K";
               
                string[] TotalFiles = Directory.GetFiles(Outputpath, "*.tif", SearchOption.AllDirectories);
                foreach (string filename in TotalFiles)
                {
    
                    Bitmap bitmap = (Bitmap)Image.FromFile(filename);
                  
                    string ExportFilename = string.Empty;
                    int Pagecount = 0;
                    bool bFirstImage = true;
                    bitmap.SetResolution(200, 200);
    
                    ExportFilename = Path.GetDirectoryName(filename) + "\\" + Path.GetFileName(filename)+"f";
                    MemoryStream byteStream = new MemoryStream();
                    Pagecount = bitmap.GetFrameCount(FrameDimension.Page);
                 
                    if (bFirstImage)
                    {
                        bitmap.Save(byteStream, ImageFormat.Tiff);
                        bFirstImage = false;
                    } Image tiff = Image.FromStream(byteStream);
                    ImageCodecInfo encoderInfo = ImageCodecInfo.GetImageEncoders().First(i => i.MimeType == "image/tiff");
                    EncoderParameters encoderParams = new EncoderParameters(2);
                    EncoderParameter parameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
                    encoderParams.Param[0] = parameter;
                    parameter = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
                    encoderParams.Param[1] = parameter;
                  //  bitmap.Dispose();
                    try
                    {
                   
                        tiff.Save(ExportFilename, encoderInfo, encoderParams);
                    }
                    catch (Exception ex)
                    {
                       
                    }
                    EncoderParameters EncoderParams = new EncoderParameters(2);
                    EncoderParameter SaveEncodeParam = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
                    EncoderParameter CompressionEncodeParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
                    EncoderParams.Param[0] = CompressionEncodeParam;
                    EncoderParams.Param[1] = SaveEncodeParam;
                    if (bFirstImage == false)
                    {
    
                        for (int i = 1; i < Pagecount; i++)
                        {
                           
                                //bitmap = (Bitmap)Image.FromFile(filenames);
                                byteStream = new MemoryStream();
                                bitmap.SelectActiveFrame(FrameDimension.Page, i);
                                bitmap.Save(byteStream, ImageFormat.Tiff);
                                bitmap.SetResolution(200, 200);
                                tiff.SaveAdd(bitmap, EncoderParams);
                            
                        }
    
                    } SaveEncodeParam = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
                    EncoderParams = new EncoderParameters(1);
                    EncoderParams.Param[0] = SaveEncodeParam;
                    tiff.SaveAdd(EncoderParams);
                    tiff.Dispose();
                    bitmap.Dispose();
                    File.Delete(filename);
                   
                }
    
    
            }
