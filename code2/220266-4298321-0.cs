1) replace LoadFromFile in Loader.cs
private static RandomObject LoadFromFile(string path)
        {
            try
            {
                var bf = new BinaryFormatter();
                using (var fileStream = File.OpenRead(path))
                using (var decompressed = new MemoryStream())
                {
                    using (var deflateStream = new DeflateStream(fileStream, CompressionMode.Decompress))
                        deflateStream.CopyTo(decompressed);
                    decompressed.Seek(0, SeekOrigin.Begin);
                    var profile = (RandomObject)bf.Deserialize(decompressed);
                    profile.SavePath = path;
                    return profile;
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
2) replace Save in Saver.cs as follows:
public static bool Save(RandomObject profile, String path)
        {
            try
            {
                var bf = new BinaryFormatter();
                using (var uncompressed = new MemoryStream())
                using (var fileStream = File.Create(path))
                {
                    bf.Serialize(uncompressed, profile);
                    uncompressed.Seek(0, SeekOrigin.Begin);
                    using (var deflateStream = new DeflateStream(fileStream, CompressionMode.Compress))
                        uncompressed.CopyTo(deflateStream);
                }
                return true;
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
