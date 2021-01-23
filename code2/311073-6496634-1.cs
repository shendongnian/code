        private static Bitmap LoadGif(string path) {
            var bmp = new Bitmap(path);
            bool found = false;
            foreach (System.Drawing.Imaging.PropertyItem item in bmp.PropertyItems) {
                if (item.Id == 20740) {
                    int paletteIndex = item.Value[0];
                    Color backGround = bmp.Palette.Entries[paletteIndex];
                    bmp.MakeTransparent(backGround);
                    found = true;
                    break;
                }
            }
            // Property missing, punt at the color of the lower-left pixel
            //if (!found) bmp.MakeTransparent();
            return bmp;
        }
