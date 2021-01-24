      Texture2D texture = new Texture2D(1,1); // the following needs a non null starting poin
      var path=System.IO.Path.Combine(Application.streamingAssetsPath,"your_file.jpg");
      byte[] bytes=System.IO.File.ReadAllBytes(path);
      texture.LoadImage(bytes);
      
      rawImage.texture=texture;
