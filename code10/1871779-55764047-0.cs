     public partial class Form1 : Form
        {
            private unsafe float* buff;
    
            public unsafe Form1()
            {
                InitializeComponent();
                buff = (float*)Marshal.AllocHGlobal(this.ClientSize.Width * this.ClientSize.Height * 4 * sizeof(float));
            }
    
            private unsafe void Form1_Paint(object sender, PaintEventArgs e)
            {
                var sw = Stopwatch.StartNew();
    
                var b = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                var bd = b.LockBits(this.ClientRectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
    
                //this is more of a GPU work, but for simplicity i put it on CPU:
                var hy = bd.Scan0;
                for (int y = 0; y < this.ClientSize.Height; ++y, hy += bd.Stride)
                {
                    var hx = hy;
                    for (int x = 0; x < this.ClientSize.Width; ++x, hx += 4, buff += 4)
                    {
                        var p = (byte*)hx;
                        p[3] = Convert.ToByte(buff[0] * 255);
                        p[2] = Convert.ToByte(buff[1] * 255);
                        p[1] = Convert.ToByte(buff[2] * 255);
                        p[0] = Convert.ToByte(buff[3] * 255);
                    }
                }
    
                b.UnlockBits(bd);
                e.Graphics.DrawImage(b, 0, 0);
                sw.Stop();
    
                Debug.WriteLine($"Frame took {sw.Elapsed}ms to draw");
            }
        }
