public static ImageSource ToImageSource()
{   
   Bitmap bitmap = Properties.Resources.Image;
   IntPtr hBitmap = bitmap.GetHbitmap();
   ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(
       hBitmap,
       IntPtr.Zero,
       Int32Rect.Empty,
       BitmapSizeOptions.FromEmptyOptions());
   RenderOptions.SetBitmapScalingMode(wpfBitmap, BitmapScalingMode.NearestNeighbor);
   return wpfBitmap;
}
