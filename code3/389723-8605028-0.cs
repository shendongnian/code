            var bmp = Image.FromFile("c:/temp/8bpp.bmp");
            if (bmp.PixelFormat != System.Drawing.Imaging.PixelFormat.Format8bppIndexed) throw new InvalidOperationException();
            var newPalette = bmp.Palette;
            for (int index = 0; index < bmp.Palette.Entries.Length; ++index) {
                var entry = bmp.Palette.Entries[index];
                var gray = (int)(0.30 * entry.R + 0.59 * entry.G + 0.11 * entry.B);
                newPalette.Entries[index] = Color.FromArgb(gray, gray, gray);
            }
            bmp.Palette = newPalette;    // Yes, assignment to self is intended
            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = bmp;
