    public static Image CreateNonIndexedImage(string path) { 
      using (var sourceImage = Image.FromFile(path)) { 
        var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height, 
          PixelFormat.Format32bppArgb); 
        using (var canvas = Graphics.FromImage(targetImage)) { 
          canvas.DrawImageUnscaled(sourceImage, 0, 0); 
        } 
        return targetImage; 
      } 
    } 
     
    [DllImport("Kernel32.dll", EntryPoint = "CopyMemory")] 
    private extern static void CopyMemory(IntPtr dest, IntPtr src, uint length); 
     
    public static Image CreateIndexedImage(string path) { 
      using (var sourceImage = (Bitmap)Image.FromFile(path)) { 
        var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height, 
          sourceImage.PixelFormat); 
        var sourceData = sourceImage.LockBits(
          new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), 
          ImageLockMode.ReadOnly, sourceImage.PixelFormat); 
        var targetData = targetImage.LockBits(
          new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), 
          ImageLockMode.WriteOnly, targetImage.PixelFormat); 
        CopyMemory(targetData.Scan0, sourceData.Scan0, 
          (uint)sourceData.Stride * (uint)sourceData.Height); 
        sourceImage.UnlockBits(sourceData); 
        targetImage.UnlockBits(targetData); 
        targetImage.Palette = sourceImage.Palette;
        return targetImage; 
      } 
    } 
