    public static object lockObject = new object();
    void UploadFile(...)
    {
        //-- other code
    	lock (lockObject)
    	{
            int i = 1;
            string saveFileAs = "MyFile.txt";
            while (File.Exists(saveFileAs))
            {
               string fileNameWithoutExt = Path.GetFileNameWithoutExtension(saveFileAs);
               string ext = Path.GetExtension(saveFileAs)
               saveFileAs = String.Concat(fileNameWithoutExt, "(", i.ToString(), ")", ext);
               i++;
            }
        
            //-- Now you can save the file.
        }
    }
