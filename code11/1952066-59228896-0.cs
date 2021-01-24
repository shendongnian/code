    System.Threading.Tasks.Task<object> t3 = System.Threading.Tasks.Task.Factory.StartNew(() => {
    
            ImageCreator ic = new ImageCreator();
            return ic.createImageFromData(textureData.normalImageData, data.width, data.height);    
        });
