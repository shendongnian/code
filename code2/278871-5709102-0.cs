            var size = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var capture = new System.Drawing.Bitmap(size.Width, size.Height);
            var g = System.Drawing.Graphics.FromImage(capture);
            g.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(size.Width, size.Height));
            g.Dispose();
