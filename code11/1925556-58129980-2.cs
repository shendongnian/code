    public void AddThumbnailImage(ThumbnailImages tImage)
            {
                if (tImage == ThumbnailImages.NULL)
                {
                    ImagesToShow.Clear();
                }
                else
                {
                    if (!ImagesToShow.Contains((int)tImage))
                        ImagesToShow.Add((int)tImage);
                }
            }
