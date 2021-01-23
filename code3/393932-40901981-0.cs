            Bitmap bitmapImage = new Bitmap(width: 1600, height: 8000);
            using (Graphics g = Graphics.FromImage(bitmapImage))
            {
                var imageRect = new Rectangle(x: 0, y: 0, width: 1600, height: 8000);
                System.Drawing.Text.InstalledFontCollection installedFontCollection = new System.Drawing.Text.InstalledFontCollection();
                FontFamily[] fontFamilies = installedFontCollection.Families;
                var format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Near;
                format.FormatFlags = StringFormatFlags.NoWrap;
                int verticalOffset = 0;
                for (int j = 0; j < fontFamilies.Length; ++j)
                {
                    using (var font = new Font(fontFamilies[j].Name, 40, FontStyle.Regular, GraphicsUnit.Pixel))
                    {
                        // Height
                        var textSize = g.MeasureString(fontFamilies[j].Name, font);
                        int textWidth = (int)Math.Ceiling(textSize.Width + 10);
                        int textHeight = (int)Math.Ceiling(textSize.Height + 10);
                        // Draw text
                        Rectangle textRect = new Rectangle(x: j % 2 == 0 ? 0 : 800, y: verticalOffset, width: textWidth, height: textHeight);
                        g.FillRectangle(new SolidBrush(BackgroundColor), textRect);
                        g.DrawString(fontFamilies[j].Name, font, new SolidBrush(PercentageTextColor), textRect, format);
                        g.Save();
                        if (j % 2 == 1)
                        {
                            verticalOffset += textHeight;
                        }
                    }
                }
            }
            bitmapImage.Save(this.Response.OutputStream, ImageFormat.Png);
            // then do whatever you like with this bitmapImage, save it to local, etc.
