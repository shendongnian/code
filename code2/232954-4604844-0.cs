    public string SaveImageFile(Stream postedFileStream, string fileDirectory, string fileName, int imageWidth, int imageHeight)
            {
                string result = "";
                string fullFilePath = Path.Combine(fileDirectory, fileName);
                string exhelp = "";
                if (!File.Exists(fullFilePath))
                {
                    try
                    {
                        using(var memoryStream = new MemoryStream())
                        {
                           postedFileStream.CopyTo(memoryStream);
                           memoryStream.Position = 0;
                           using (var postedBitmap = new Bitmap(memoryStream))
                           {
                             .........
                            }
    
                        }
                    }
    
                    catch (Exception ex)
    
                    {
    
                        result = "Save Image File Failed " + ex.Message + ex.StackTrace;
    
                        Global.SendExceptionEmail("Save Image File Failed " + exhelp, ex);
    
                    }
    
                }
    
    
    
                return result;
    
            }
