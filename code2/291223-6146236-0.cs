    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    
    // ...
    
    Color[,] GetSection(Image img, Rectangle r) {
        Color[,] r = new Color[r.Width, r.Height]; // Create an array of colors to return
    
        using(Bitmap b = new Bitmap(img)) { // Turn the Image into a Bitmap
            BitmapData bd = b.LockBits(r, ImageLockMode.ReadOnly, PixelFormat.Format32BppArgb); // Lock the bitmap data
            int[] arr = new int[b.Width * b.Height - 1]; // Create an array to hold the bitmap's data
            Marshal.Copy(b.Scan0, arr, 0, arr.Length); // Copy over the data
            b.UnlockBits(bd); // Unlock the bitmap
    
            for(int i = 0; i < arr.Length; i++) {
                r[i % r.Width, i / r.Width] = Color.FromArgb(arr[i]); // Copy over into a Color structure
            }
        }
    
        return r; // Return the result
    }
