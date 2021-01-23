                try
                {
                    var image = new System.Drawing.Bitmap(filePath);
                    return string.Format("{0}px by {1}px", image.Width, image.Height);
                }
                catch (Exception)
                {
                    try
                    {
                        TagLib.File file = TagLib.File.Create(filePath);
                        return string.Format("{0}px by {1}px", file.Properties.PhotoWidth, file.Properties.PhotoHeight);
                    }
                    catch (Exception)
                    {
                        return ("");
                    }
                }
