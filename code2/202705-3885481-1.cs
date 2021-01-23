        private static Image ResizeImage(int newSize, Image originalImage)
        {
            if (originalImage.Width <= newSize)
                newSize = originalImage.Width;
            var newHeight = originalImage.Height * newSize / originalImage.Width;
            if (newHeight > newSize)
            {
                // Resize with height instead
                newSize = originalImage.Width * newSize / originalImage.Height;
                newHeight = newSize;
            }
            return originalImage.GetThumbnailImage(newSize, newHeight, null, IntPtr.Zero);
        }
