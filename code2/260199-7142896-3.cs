    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace CMYKConversion
    {
        public class Converter
        {
            public void Convert()
            {
                var rgbJpeg = BitmapFrame.Create(GetStreamFromResource("CMYKConversion.Images.Desert.jpg"));
                var iccCmykJpeg = new ColorConvertedBitmap(
                    rgbJpeg,
                    new ColorContext(PixelFormats.Default),
                    new ColorContext(GetProfilePath("Profiles/1010_ISO_Coated_39L.icc")),
                    PixelFormats.Cmyk32
                    );
                var jpegBitmapEncoder = new JpegBitmapEncoder();
                jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(iccCmykJpeg));
                var iccCmykJpegStream = new MemoryStream();
                jpegBitmapEncoder.Save(iccCmykJpegStream);
    
                iccCmykJpegStream.Flush();
                SaveMemoryStream(iccCmykJpegStream, "C:\\desertCMYK.jpg");
                iccCmykJpegStream.Close();
            }
    
            private Stream GetStreamFromResource(string name)
            {
                return typeof(Program).Assembly.GetManifestResourceStream(name);
            }
    
            private Uri GetProfilePath(string name)
            {
                string folder = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).CodeBase);
                return new Uri(Path.Combine(folder, name));
            }
    
            private void SaveMemoryStream(MemoryStream ms, string fileName)
            {
                FileStream outStream = File.OpenWrite(fileName);
                ms.WriteTo(outStream);
                outStream.Flush();
                outStream.Close();
            }
        }
    }
