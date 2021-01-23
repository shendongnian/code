        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Windows.Media.Imaging;
        using BitMiracle.LibTiff.Classic;
        namespace CoreTechs.X9
        {
            public static class TiffUtility
            {
                public static Tiff CreateTiff(this byte[] bytes)
                {
                    MemoryStream ms = new MemoryStream(bytes);
                    Tiff tiff = Tiff.ClientOpen("in-memory", "r", ms, new TiffStream());
                    return tiff;
                }
                public static IEnumerable<WriteableBitmap> ConvertToWriteableBitmaps(this Tiff tiff)
                {
                    if (tiff == null)
                        throw new ArgumentNullException("tiff", "tiff is null.");
                    short dirs = tiff.NumberOfDirectories();
                    for (int i = 0; i < dirs; i++)
                    {
                        if (tiff.SetDirectory((short)i))
                        {
                            int tileCount = tiff.NumberOfTiles();
                            int stripCount = tiff.NumberOfStrips();
                            var frameWidthField = tiff.GetField(TiffTag.IMAGEWIDTH);
                            var frameHeightField = tiff.GetField(TiffTag.IMAGELENGTH);
                            var compressionField = tiff.GetField(TiffTag.COMPRESSION);
                            var xResolutionField = tiff.GetField(TiffTag.XRESOLUTION);
                            var yResolutionField = tiff.GetField(TiffTag.YRESOLUTION);
                            var samplesPerPixelField = tiff.GetField(TiffTag.SAMPLESPERPIXEL);
                            int frameWidth = frameWidthField != null && frameWidthField.Length > 0 ? frameWidthField[0].ToInt() : 0;
                            int frameHeight = frameHeightField != null && frameHeightField.Length > 0 ? frameHeightField[0].ToInt() : 0;
                            var compression = compressionField != null && compressionField.Length > 0 ? (Compression)compressionField[0].Value : Compression.NONE;
                            var xResolution = xResolutionField != null && xResolutionField.Length > 0 ? new double?(xResolutionField[0].ToDouble()) : null;
                            var yResolution = yResolutionField != null && yResolutionField.Length > 0 ? new double?(yResolutionField[0].ToDouble()) : null;
                            var samplesPerPixel = samplesPerPixelField != null && samplesPerPixelField.Length > 0 ? samplesPerPixelField[0].ToString() : String.Empty;
                            if (xResolution != null && yResolution == null)
                            {
                                yResolution = xResolution;
                            }
                            var buffer = new int[frameWidth * frameHeight];
                            tiff.ReadRGBAImage(frameWidth, frameHeight, buffer);
                            var bmp = new WriteableBitmap(frameWidth, frameHeight);
                            for (int y = 0; y < frameHeight; y++)
                            {
                                var ytif = y * frameWidth;
                                var ybmp = (frameHeight - y - 1) * frameWidth;
                                for (int x = 0; x < frameWidth; x++)
                                {
                                    var currentValue = buffer[ytif + x];
                                    // Shift the Tiff's RGBA format to the Silverlight WriteableBitmap's ARGB format
                                    bmp.Pixels[ybmp + x] = Tiff.GetB(currentValue) | Tiff.GetG(currentValue) << 8 | Tiff.GetR(currentValue) << 16 | Tiff.GetA(currentValue) << 24;
                                }
                            }
                            yield return bmp;
                        }
                    }
                }
            }
        }
