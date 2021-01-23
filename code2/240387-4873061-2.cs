    private static Bitmap ResizeImage(Image image, int width, int height)
            {
                var frameCount = image.GetFrameCount(new FrameDimension(image.FrameDimensionsList[0]));
                var newDimensions = ImageFunctions.GenerateImageDimensions(image.Width, image.Height, width, height);
                Bitmap resizedImage;
    
                if (frameCount > 1)
                {
                    //we have a animated GIF
                    resizedImage = ResizeAnimatedGifImage(image, width, height);
                }
                else
                {
                    resizedImage = (Bitmap)image.GetThumbnailImage(newDimensions.Width, newDimensions.Height, null, IntPtr.Zero);
                }
    
                resizedImage.SetResolution(72,72);
    
                return resizedImage;
            }
