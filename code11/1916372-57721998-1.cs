    public static class BitmapExtensions
    {
        public static Bitmap ToGrayscale( this Bitmap source, CancellationToken cancellationToken = default )
        {
            Bitmap output = new Bitmap( source.Width, source.Height );
            for ( int i = 0; i < source.Width; i++ )
            {
                for ( int x = 0; x < source.Height; x++ )
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var imageColor = source.GetPixel( i, x );
                    int grayScale = (int)( ( imageColor.R * 0.21 ) + ( imageColor.G * 0.72 ) + ( imageColor.B * 0.07 ) );
                    var newColor = System.Drawing.Color.FromArgb( imageColor.A, grayScale, grayScale, grayScale );
                    output.SetPixel( i, x, newColor );
                }
            }
            return output;
        }
        public static Bitmap ToBitmap( this BitmapImage source )
        {
            using ( MemoryStream outStream = new MemoryStream() )
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add( BitmapFrame.Create( source ) );
                enc.Save( outStream );
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap( outStream );
                return new Bitmap( bitmap );
            }
        }
        public static BitmapImage ToBitmapImage( this Bitmap source )
        {
            using ( var memory = new MemoryStream() )
            {
                source.Save( memory, ImageFormat.Png );
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }
    }
