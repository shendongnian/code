        private byte[] JpegBytesFromDicomStream(Stream stream)
        {
            byte[] result;
            // Open image from Stream using DicomFile class
            DicomFile file = DicomFile.Open(stream);
            DicomImage image = new DicomImage(file.Dataset);
            using (IImage renderedImage = image.RenderImage())
            {
                Bitmap bitmap = renderedImage.AsSharedBitmap();
                // Copy image to byte array using MemoryStream
                using (MemoryStream targetStream = new MemoryStream())
                {
                    bitmap.Save(targetStream, ImageFormat.Jpeg);
                    result = targetStream.ToArray();
                }
            }
            return result;
        }
