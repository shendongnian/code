    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Media.Imaging;
    namespace wictest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var stream = new FileStream("1.jpg", FileMode.Open, FileAccess.Read);
                var decoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.None, BitmapCacheOption.None);
                var metadata = decoder.Frames[0].Metadata as BitmapMetadata;
                if(metadata != null)
                    Console.WriteLine(metadata.Keywords.Aggregate((old, val) => old + "; " + val));
                Console.ReadLine();
            }
        }
    }
