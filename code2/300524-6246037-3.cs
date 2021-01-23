    byte[] streamData;    
          
    using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
         using (IsolatedStorageFileStream isfs = isf.OpenFile("image.png", FileMode.Open, FileAccess.Read))
         {
              streamData = new byte[isfs.Length];
              isfs.Read(streamData, 0, streamData.Length);              
         }
    }
    
    MemoryStream ms = new MemoryStream(streamData);
    BitmapImage bmpImage= new BitmapImage();
    bmpImage.SetSource(ms);
    image1.Source = bmpImage; //image1 being your Image control
