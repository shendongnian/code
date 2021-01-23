    // your original ToGreyscale modified
        private void ToGrayscale()      
        {      
            Bitmap greyscaleImage = ConvertToGreyscale(CurrentImage.LoadedImage.ToBitmap());      
            AddSnapshot(greyscaleImage, "Desaturate");      
            CurrentImage.LoadedImage = greyscaleImage .ToBitmapImage();      
            UiImageContainer.Source = CurrentImage.LoadedImage;      
        }      
    // put this in another class
        private Bitmap ConvertToGrayscale(Bitmap originalImage) 
        { 
            var drawing = new Bitmap(originalImage.Width, originalImage.Height); 
            var drawingsurface = Graphics.FromImage(drawing); 
            var attributes = new ImageAttributes(); 
            attributes.SetColorMatrix(ImageFilters.GrayScaleMatrix); 
            drawingsurface.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, originalImage.Width, originalImage.Height), 
                                       0, 0, template.Width, template.Height, GraphicsUnit.Pixel, attributes); 
            drawingsurface.Dispose(); 
           return drawing
                        } 
