      static void Main()
      {
          SaveThumbnail("new.jpg", 64); // auto jpg
          SaveThumbnail("new.jpg", 64, "new.png"); // explicit png output
      }
      public static void SaveThumbnail(string inputFilePath, int thumbnailSize, string outputFilePath = null)
      {
          if (inputFilePath == null)
              throw new ArgumentNullException(inputFilePath);
          // decode frame
          var frame = BitmapDecoder.Create(new Uri(inputFilePath, UriKind.RelativeOrAbsolute), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None).Frames[0];
          // read input transformations
          var transformations = new Transformations(frame.Metadata as BitmapMetadata);
          int width;
          int height;
          if (frame.Width > frame.Height)
          {
              width = thumbnailSize;
              height = (int)(frame.Height * thumbnailSize / frame.Width);
          }
          else
          {
              width = (int)(frame.Width * thumbnailSize / frame.Height);
              height = thumbnailSize;
          }
          Guid containerFormat;
          if (outputFilePath == null)
          {
              // use input format same as decode.
              containerFormat = frame.Decoder.CodecInfo.ContainerFormat;
              outputFilePath = Path.ChangeExtension(inputFilePath, thumbnailSize + Path.GetExtension(inputFilePath));
          }
          else
          {
              // icing on the cake..., we determine the format from the output file extension, using some WIC voodoo (code below)
              // you could make it simpler and harcode things out but this way you can use other 3rd parties codecs
              containerFormat = WicUtilities.EnumerateDecoderFormatsForExtension(Path.GetExtension(outputFilePath)).FirstOrDefault();
              if (containerFormat == Guid.Empty) // this extension is not supported on this system
                  throw new ArgumentNullException(outputFilePath);
          }
          var encoder = BitmapEncoder.Create(containerFormat);
          Transform transform = new ScaleTransform(width / frame.Width * 96 / frame.DpiX, height / frame.Height * 96 / frame.DpiY, 0, 0);
          // the jpeg encoder has a built-in flip & rotate system
          if (encoder is JpegBitmapEncoder jpeg)
          {
              // exif is counter clockwise
              switch (transformations.Rotation)
              {
                  case Rotation.Rotate90:
                      jpeg.Rotation = Rotation.Rotate270;
                      break;
                  case Rotation.Rotate180:
                      jpeg.Rotation = Rotation.Rotate180;
                      break;
                  case Rotation.Rotate270:
                      jpeg.Rotation = Rotation.Rotate90;
                      break;
              }
              jpeg.FlipVertical = transformations.FlipVertical;
              jpeg.FlipHorizontal = transformations.FlipHorizontal;
              // option: change quality level here
              // jpeg.QualityLevel = xx
          }
          else
          {
              // other codecs need transform
              var group = new TransformGroup();
              // we must flip before rotate
              // https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/how-to-flip-a-uielement-horizontally-or-vertically
              if (transformations.FlipHorizontal)
              {
                  group.Children.Add(new ScaleTransform(-1, 1, 0.5, 0.5));
              }
              
              if (transformations.FlipVertical)
              {
                  group.Children.Add(new ScaleTransform(1, -1, 0.5, 0.5));
              }
              // exif is counter clockwise
              switch (transformations.Rotation)
              {
                  case Rotation.Rotate90:
                      group.Children.Add(new RotateTransform(270));
                      break;
                  case Rotation.Rotate180:
                      group.Children.Add(new RotateTransform(180));
                      break;
                  case Rotation.Rotate270:
                      group.Children.Add(new RotateTransform(90));
                      break;
              }
              // I scale *after* rotate/flip, but it's up to you, not sure it changes anything in perf or quality...
              group.Children.Add(transform);
              transform = group;
          }
          var resized = BitmapFrame.Create(new TransformedBitmap(frame, transform));
          encoder.Frames.Add(resized);
          using (var stream = File.OpenWrite(outputFilePath))
          {
              encoder.Save(stream);
          }
      }
    // helper class that exposes supported transformations (rotate/flip)
    public class Transformations
    {
        public Transformations(BitmapMetadata md)
        {
            // https://docs.microsoft.com/en-us/uwp/api/windows.storage.fileproperties.photoorientation
            // https://docs.microsoft.com/en-us/windows/win32/wic/-wic-photoprop-system-photo-orientation
            // https://docs.microsoft.com/en-us/windows/win32/properties/props-system-photo-orientation
            const string orientationProperty = "System.Photo.Orientation";
            if (md != null && md.ContainsQuery(orientationProperty))
            {
                var orientation = (Orientation)md.GetQuery(orientationProperty);
                switch (orientation)
                {
                    case Orientation.FlipHorizontal:
                        FlipHorizontal = true;
                        break;
                    case Orientation.FlipVertical:
                        FlipVertical = true;
                        break;
                    case Orientation.Rotate90:
                        Rotation = Rotation.Rotate90;
                        break;
                    case Orientation.Rotate180:
                        Rotation = Rotation.Rotate180;
                        break;
                    case Orientation.Rotate270:
                        Rotation = Rotation.Rotate270;
                        break;
                    case Orientation.Transpose:
                        Rotation = Rotation.Rotate90;
                        FlipHorizontal = true;
                        break;
                    case Orientation.Transverse:
                        Rotation = Rotation.Rotate270;
                        FlipHorizontal = true;
                        break;
                }
            }
        }
        public Rotation Rotation { get; set; }
        public bool FlipHorizontal { get; set; }
        public bool FlipVertical { get; set; }
    }
    public enum Orientation : ushort
    {
        Undefined,
        Normal,
        FlipHorizontal,
        Rotate180,
        FlipVertical,
        Transpose,
        Rotate270,
        Transverse,
        Rotate90
    }
    // some WIC tool, need System.Runtime.InteropServices namespace
    public static class WicUtilities
    {
        public static IEnumerable<Guid> EnumerateEncoderFormatsForExtension(string extension) => EnumerateFormatsForExtension(WICComponentType.WICEncoder, extension);
        public static IEnumerable<Guid> EnumerateDecoderFormatsForExtension(string extension) => EnumerateFormatsForExtension(WICComponentType.WICDecoder, extension);
        private static IEnumerable<Guid> EnumerateFormatsForExtension(WICComponentType type, string extension)
        {
            if (extension == null)
                throw new ArgumentNullException(nameof(extension));
            foreach (var info in EnumerateCodecs(type))
            {
                info.GetFileExtensions(0, null, out var len);
                if (len >= 0)
                {
                    var sb = new StringBuilder(len);
                    info.GetFileExtensions(len + 1, sb, out _);
                    var supportedExtensions = sb.ToString().Split(',');
                    if (supportedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                    {
                        if (info.GetContainerFormat(out var format) == 0)
                            yield return format;
                    }
                }
            }
        }
        private static IEnumerable<IWICBitmapCodecInfo> EnumerateCodecs(WICComponentType type)
        {
            var wfac = (IWICImagingFactory)new WICImagingFactory();
            wfac.CreateComponentEnumerator(type, 0, out var unks);
            if (unks != null)
            {
                var array = new object[1];
                do
                {
                    if (unks.Next(1, array, out var _) != 0)
                        break;
                    yield return (IWICBitmapCodecInfo)array[0];
                }
                while (true);
            }
        }
        [Guid("CACAF262-9370-4615-A13B-9F5539DA4C0A"), ComImport]
        private class WICImagingFactory { }
        [Guid("00000100-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IEnumUnknown
        {
            [PreserveSig]
            int Next(int celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown)] object[] rgelt, out int celtFetched);
            // we don't need the rest
        }
        [Flags]
        private enum WICComponentType
        {
            WICDecoder = 0x1,
            WICEncoder = 0x2,
            // we don't need the rest
        }
        [Guid("ec5ec8a9-c395-4314-9c77-54d7a935ff70"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICImagingFactory
        {
            void _VtblGap1_20(); // skip 20 methods we don't need
            [PreserveSig]
            int CreateComponentEnumerator(WICComponentType componentTypes, int options, out IEnumUnknown ppIEnumUnknown);
            // we don't need the rest
        }
        [Guid("E87A44C4-B76E-4c47-8B09-298EB12A2714"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IWICBitmapCodecInfo
        {
            void _VtblGap1_8(); // skip 8 methods we don't need
            [PreserveSig]
            int GetContainerFormat(out Guid pguidContainerFormat);
            void _VtblGap2_5(); // skip 5 methods we don't need
            [PreserveSig]
            int GetFileExtensions(int cchFileExtensions, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzFileExtensions, out int pcchActual);
            // we don't need the rest
        }
    }
