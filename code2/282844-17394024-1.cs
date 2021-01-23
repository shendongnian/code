    Private void SaveResourceImage() {
        object resBmpObject = Resource.Image1.Clone();//Bitmap Image from resource file
        //object resBmpObject = anyBmpImage.clone(); //for image other than resource image
        Bitmap resBmpImage = (Bitmap)resBmpObject;
        resBmpImage.Save(destFilePath, System.Drawing.Imaging.ImageFormat.Png);
        resBmpImage.dispose();
    }
