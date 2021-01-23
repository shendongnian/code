    static void DrawSomethingToBitmap(Image img, string text)
        {
            Graphics g = Graphics.FromImage(img);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Gray, 
                img.Width/2, img.Height/2);
        }
