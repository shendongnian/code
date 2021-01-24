    public enum MediaType
    {
        Audio,
        Video,
        Image,
        None
    }
     
    class MyData
    {
         private byte mydata = null;
         private MediaType type = MediaType.None;
         public void SetData(byte[] data)
         {
              mydata = data;
              if(ImageValidation())  // a method that validates data is a valid image
                  type = MediaType.Image;
              else if(VideoValidation())
                  type = MediaType.Video;
              else if(AutioValidation())
                  type = MediaType.Audio;
              else
                  type = MediaType.None;
         }
    
         //I'm not going to create all get functions but just for one type
         
         public bool ContainsImage()   //costless
         {
              return type == MediaType.Image;
         }
    
         public Image GetImage()  //costly if there is an image
         {
              if(type == MediaType.Image)
                  using (var ms = new MemoryStream(mydata))
                  {
                       return Image.FromStream(ms);    
                  }
              else
                  return null;
         }
    }
