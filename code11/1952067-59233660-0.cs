    ImageTexture terrainTexture = new ImageTexture();
        ImageTexture soilTexture = new ImageTexture();
        ImageTexture normalTexture = new ImageTexture();
        byte[] heightImageData = textureData.heightImageData;
        byte[] soilImageData = textureData.soilThicknessImageData;
        byte[] normalImageData = textureData.normalImageData;
        int width = data.width;
        int height = data.height;
        System.Threading.Tasks.Task t1 = System.Threading.Tasks.Task.Factory.StartNew(() => {
            createImageFromData(heightImageData, terrainTexture, width, height);
        });
        System.Threading.Tasks.Task t3 = System.Threading.Tasks.Task.Factory.StartNew(() => {
            createImageFromData(normalImageData, normalTexture, width, height);
        });
        System.Threading.Tasks.Task t = System.Threading.Tasks.Task.WhenAll(t1,t3);
  
        t.Wait();
