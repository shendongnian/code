    using DotSpatial.Data;
    using System.IO;
    using System.IO.Compression;
    
    namespace ConsoleApp12
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var fs = File.OpenRead(@"C:\Users\jjjjjjjjjjjj\Downloads\1270055001_mb_2011_vic_shape.zip"))
                using (var zipFile = new ZipArchive(fs))
                {
                    foreach (var entry in zipFile.Entries)
                    {
                        if (entry.FullName.EndsWith(".shp"))
                        {
                            var tempFile = Path.GetTempFileName();
                            try
                            {
                                using (var entryStream = entry.Open())
                                using (var newFileStream = File.OpenWrite(tempFile))
                                {
                                    entryStream.CopyTo(newFileStream);
                                }
                                var featureSource = ShapefileFeatureSource.Open(tempFile);
                                var type = featureSource.ShapeType;
                            }
                            finally
                            {
                                File.Delete(tempFile);
                            }
                        }
                    }
                }
            }
        }
    }
