     public String UploadFile(byte[] fileByte, String fileName, String savePath)
            {
    
                string newPath = savePath;
    
    
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
    
                newPath = newPath + fileName;
    
                System.IO.FileStream fs1 = null;
                byte[] b1 = null;
                b1 = fileByte;
                fs1 = new FileStream(newPath, FileMode.Create);
                fs1.Write(b1, 0, b1.Length);
                fs1.Flush();
                fs1.Close();
                fs1 = null;
    
                return newPath;
            }
