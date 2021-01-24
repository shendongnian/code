lang-csharp
using System;
using System.Drawing;
using System.Runtime.InteropServices;
namespace Example
{
   class Program
   {
      static void Main(string[] args)
      {
         IntPtr bitmapData = IntPtr.Zero; //Declaring it here and passing it to IntsToBitmap because it needs to be freed.
         try
         {
            int[] pixels = new int[32 * 32]; //32x32 bitmap.
            for (int i = 0; i < pixels.Length; i++)
            {
               pixels[i] = 4080;
            }
            var bmp = IntsToBitmap(pixels, 32, 32, out bitmapData);
            //bmp.Save("SomefilePath") //If you want to see the bitmap.
            var bmpPixels = BitmapToInts(bmp, 0, 0, 32, 32);
            bmp.Dispose();
         }
         finally
         {
            if (bitmapData != IntPtr.Zero)
            {
               Marshal.FreeHGlobal(bitmapData);
            }
         }
      }
      static int[] BitmapToInts(Bitmap bitmap, int x, int y, int width, int height)
      {
         var bitmapData = bitmap.LockBits(
            new Rectangle(x, y, width, height), 
            System.Drawing.Imaging.ImageLockMode.ReadOnly, 
            bitmap.PixelFormat);
         var lengthInBytes = bitmapData.Stride * bitmapData.Height;
         int[] pixels = new int[lengthInBytes / 4];
         Marshal.Copy(bitmapData.Scan0, pixels, 0, pixels.Length);
         bitmap.UnlockBits(bitmapData);
         return pixels;
      }
      static Bitmap IntsToBitmap(int[] pixels, int width, int height, out IntPtr bitmapData)
      {
         bitmapData = Marshal.AllocHGlobal(width * height * 4);
         Marshal.Copy(pixels, 0, bitmapData, pixels.Length);
         return new Bitmap(width, height, 4 * width, System.Drawing.Imaging.PixelFormat.Format32bppArgb, bitmapData);
      }
   }
}
