        public static Bitmap ToBitmap(this Microsoft.Xna.Framework.Graphics.Texture2D rd, int Width, int Height)
        {
            var Bmp = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            byte[] data = ToBytes(rd);
            var bmpData = Bmp.LockBits(new Rectangle(0, 0, rd.Width, rd.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
            Bmp.UnlockBits(bmpData);
            return Bmp;
        }
        public static byte[] ToBytes(this Microsoft.Xna.Framework.Graphics.Texture2D rd)
        {
            byte[] data = new byte[4 * rd.Height * rd.Width];
            rd.GetData<byte>(data);
            SwapBytes(data);
            return data;
        }
        private static void SwapBytes(byte[] data)
        {
            System.Threading.Tasks.ParallelOptions po = new System.Threading.Tasks.ParallelOptions();
            po.MaxDegreeOfParallelism = -1;
            System.Threading.Tasks.Parallel.For(0, data.Length / 4, po, t =>
            {
                int bi = t * 4;
                byte temp = data[bi];
                data[bi] = data[bi + 2];
                data[bi + 2] = temp;
            });
        }
