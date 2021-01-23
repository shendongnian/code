    using System;
    using System.Linq;
    using System.Drawing.Imaging;
    using Emgu.CV.Structure;
    
    public static class EmguImageSave
    {
        /// <summary>
        /// Save a jpeg image with a specified quality
        /// </summary>
        /// <param name="path">Name of the file to which to save the image</param>
        /// <param name="quality">Byte that specifies JPEG Quality of the image encoder</param>
        public static void Save( this Emgu.CV.Image<Bgr, Byte> img, string filename, double quality )
        {
            var encoderParams = new EncoderParameters( 1 );
            encoderParams.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.Quality,
                (long)quality
                );
    
            var jpegCodec = (from codec in ImageCodecInfo.GetImageEncoders()
                             where codec.MimeType == "image/jpeg"
                             select codec).Single();
    
            img.Bitmap.Save( filename, jpegCodec, encoderParams );
        }
    }
