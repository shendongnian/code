       static List<string> GenerateDeviceIcon2(string backgroundImageFile, string deviceImageFile,
                string deviceNumber, int deviceID, string saveNewFilePath, string fontName, int fontSize, Color textColor)
            {
                var r = new List<string>();
    
                try
                {
                    Image background = Image.FromFile(backgroundImageFile);
                    Image logo = Image.FromFile(deviceImageFile);
                    PointF firstLocation = new PointF(2f, 2f);
    
                    #region Create text as Image with Transparancy
    
                    //first, create a dummy bitmap just to get a graphics object
                    Image img = new Bitmap(1, 1);
                    Graphics drawingText = Graphics.FromImage(img);
                    //measure the string to see how big the image needs to be
                    int maxWidth = background.Width - 2;
                    var font = new Font(fontName, fontSize, new FontStyle());
                    SizeF textSize = drawingText.MeasureString(deviceNumber, font, maxWidth);
    
                    //set the stringformat flags to rtl
                    StringFormat sf = new StringFormat
                    {
                        //uncomment the next line for right to left languages
                        //sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                        Trimming = StringTrimming.Word
                    };
    
                    //free up the dummy image and old graphics object
                    img.Dispose();
                    drawingText.Dispose();
    
                    //create a new image of the right size
                    img = new Bitmap((int)textSize.Width, (int)textSize.Height);
                    // drawingText = Graphics.FromImage(img);
                    #endregion
                    //create a brush for the text
                    Brush textBrush = new SolidBrush(textColor);
    
                    using (background)
                    {
                        using (var bitmap = new Bitmap(background.Width, background.Height))
                        {
                            using (var canvas = Graphics.FromImage(bitmap))
                            {
                                //Adjust for high quality
                                canvas.CompositingQuality = CompositingQuality.HighQuality;
                                canvas.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                canvas.SmoothingMode = SmoothingMode.HighQuality;
                                canvas.TextRenderingHint = TextRenderingHint.AntiAliasGridFit; 
    
                                //paint the background
                                canvas.Clear(Color.Transparent);
    
                                // First - draw a background!
                                canvas.DrawImage(background, new Rectangle(0, 0, background.Width, background.Height),
                                                    new Rectangle(0, 0, background.Width, background.Height), GraphicsUnit.Pixel);
    
                                // Second - draw the text in multiple rows over background
                                canvas.DrawImage(logo, (bitmap.Width / 2) - (logo.Width / 2), (bitmap.Height / 2) - (logo.Height / 2));
    
                                // Third - draw the logo over background
                                canvas.DrawString(deviceNumber, font, textBrush, new RectangleF(0, 0, textSize.Width, textSize.Height), sf);
    
                                canvas.Save();
                            }
    
                            try
                            {
                                var filename = Path.Combine(saveNewFilePath, deviceID.ToString() + ".png");
    
                                if (File.Exists(filename))
                                {
                                    File.Delete(filename);
                                }
    
                                bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            catch (Exception ex)
                            {
                                r.Add(ex.Message);
                            }
                        }
                    }
    
                    textBrush.Dispose();
                    img.Dispose();
                }
                catch (Exception ex)
                {
                    r.Add(ex.Message);
                }
    
                return r;
            }
