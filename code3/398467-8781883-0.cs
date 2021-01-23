    public bool ImageCrop(int X, int Y, int W, int H) {
      using (Bitmap original = imageObject) {
        imageObject = original.Clone(new Rectangle(X, Y, W, H), imageObject.PixelFormat);
      }
    }
