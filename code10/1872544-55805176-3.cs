    public void saveImageToGally(Bitmap finalBitmap,Context context)
        {
            //create a directory called MyCamera
            string root = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDcim).ToString() + "/MyCamera/";
           //create the Directory
            System.IO.Directory.CreateDirectory(root);
            File myDir = new File(root);
            myDir.Mkdir();
            //Image name
            string fname = "Image-" + "Image1" + ".png";
            File file = new File(myDir, fname);
            Log.Error("FilePath", file.AbsolutePath);
           
            if (file.Exists()) file.Delete();
            Log.Error("FilePath", root + fname);
            //total path
            string path = root + fname;
 
            try
            {
               
            
                var fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                if (fs != null)
                {
                    finalBitmap.Compress(Bitmap.CompressFormat.Png, 90, fs);
                    fs.Close();
                }
               
            }
            catch (Exception e)
            {
                e.PrintStackTrace();
            
            }
            MediaScannerConnection.ScanFile(context, new string[] { file.Path }, new string[] { "image/jpeg" }, null);
        }
