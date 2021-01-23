    //make sure PNG_IMAGE is set as 'Content' build type
    var pngStream= Application.GetResourceStream(new Uri(PNG_IMAGE, UriKind.Relative)).Stream;
   
    int counter;
    byte[] buffer = new byte[1024];
    using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
       using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(IMAGE_NAME, FileMode.Create, isf))
       {
          counter = 0;
          while (0 < (counter = pngStream.Read(buffer, 0, buffer.Length)))
          {
                 isfs.Write(buffer, 0, counter);
          }    
          
          pngStream.Close();
          
        }
     }
