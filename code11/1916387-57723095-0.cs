    List<System.IO.Stream> streamList = new List<System.IO.Stream>();
    AssetManager assetManager = Assets;
    string[] images = assetManager.List("");
    for (int i = 0; i < images.Length; i++)
       {
         if (images[i].EndsWith(".png"))
           {
              using (StreamReader sr = new StreamReader(assetManager.Open(images[i])))
                 {
                   streamList.Add(sr.BaseStream);
                 }
           }
       }
