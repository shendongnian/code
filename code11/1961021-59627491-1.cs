     public void OpenGallery()
        {
            try
            {
                var imageIntent = new Intent(Intent.ActionPick);
                imageIntent.SetType("image/*");
                imageIntent.PutExtra(Intent.ExtraAllowMultiple, true);
                imageIntent.SetAction(Intent.ActionGetContent);
                this.StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), OPENGALLERYCODE);
                Toast.MakeText(this, "Tap and hold to select multiple photos.", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Toast.MakeText(this, "Error. Can not continue, try again.", ToastLength.Long).Show();
            }
        }
      
		void ClearFileDirectory()
        {
            var directory = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), ImageHelpers.collectionName).Path.ToString();
            if (Directory.Exists(directory))
            {
                var list = Directory.GetFiles(directory, "*");
                if (list.Length > 0)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        File.Delete(list[i]);
                    }
                }
            }
        }
       //collectionName is the name of the folder in your Android Pictures directory.
        public static readonly string collectionName = "TmpPictures";
        public string SaveFile(byte[] imageByte, string fileName)
        {
            var fileDir = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), collectionName);
            if (!fileDir.Exists())
            {
                fileDir.Mkdirs();
            }
            var file = new Java.IO.File(fileDir, fileName);
            System.IO.File.WriteAllBytes(file.Path, imageByte);
            return file.Path;
        }
        public string CompressImage(string path)
        {
            byte[] imageBytes;
            //Get the bitmap.
            var originalImage = BitmapFactory.DecodeFile(path);
            //Set imageSize and imageCompression parameters.
            var imageSize = .86;
            var imageCompression = 67;
            //Resize it and then compress it to Jpeg.
            var width = (originalImage.Width * imageSize);
            var height = (originalImage.Height * imageSize);
            var scaledImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, true);
            using (MemoryStream ms = new MemoryStream())
            {
                scaledImage.Compress(Bitmap.CompressFormat.Jpeg, imageCompression, ms);
                imageBytes = ms.ToArray();
            }
            originalImage.Recycle();
            originalImage.Dispose();
            GC.Collect();
            return SaveFile(imageBytes, Guid.NewGuid().ToString());
        }
