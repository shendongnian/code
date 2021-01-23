        /// <summary>
        /// Resize the image.
        /// </summary>
        /// <param name="image">
        /// A System.IO.Stream object that points to an uploaded file.
        /// </param>
        /// <param name="width">
        /// The new width for the image.
        /// Height of the image is calculated based on the width parameter.
        /// </param>
        /// <returns>The resized image.</returns>
        public Image ResizeImage( Stream image, int width ) {
            try {
                using ( Image fromStream = Image.FromStream( image ) ) {
                    // calculate height based on the width parameter
                    int newHeight = ( int )(fromStream.Height / (( double )fromStream.Width / width));
                    using ( Bitmap resizedImg = new Bitmap( fromStream, width, newHeight ) ) {
                        using ( MemoryStream stream = new MemoryStream() ) {
                            resizedImg.Save( stream, fromStream.RawFormat );
                            return Image.FromStream( stream );
                        }
                    }
                }
            } catch ( Exception exp ) {
                // log error
            }
            return null;
        }
