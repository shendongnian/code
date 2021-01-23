    using BitMiracle.LibTiff.Classic;
    
    namespace ReadTiffDimensions
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (Tiff image = Tiff.Open(args[0], "r"))
                {
                    FieldValue[] value = image.GetField(TiffTag.IMAGEWIDTH);
                    int width = value[0].ToInt();
    
                    value = image.GetField(TiffTag.IMAGELENGTH);
                    int height = value[0].ToInt();
    
                    value = image.GetField(TiffTag.XRESOLUTION);
                    float dpiX = value[0].ToFloat();
    
                    value = image.GetField(TiffTag.YRESOLUTION);
                    float dpiY = value[0].ToFloat();
                }
            }
        }
    }
