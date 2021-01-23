        class MyHtmlImageEmbedder
        {
            static protected string _appDataDirectory =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    Settings.Default.ApplicationId);
    
            static public string getHtml()
            {
                String apiHelp = Resources.html_file;
                Regex regex = new Regex(@"src=\""(.*)\""", RegexOptions.IgnoreCase);
                MatchCollection mc = regex.Matches(apiHelp);
                foreach (Match m in mc)
                {
                    string filename = m.Groups[1].Value;
                    Image image = Resources.ResourceManager.GetObject(Path.GetFileNameWithoutExtension(filename)) as Image;
                    if (image != null)
                    {
                        var path = getPathTo(Path.GetFileNameWithoutExtension(filename) + ".png", imageToPngByteArray(image));
                        apiHelp = apiHelp.Replace(filename, path);
                    }
                }
                return apiHelp;
            }
    
            static public string getPathTo(string filename, byte[] contentBytes)
            {
                Directory.CreateDirectory(_appDataDirectory);
                var path = Path.Combine(_appDataDirectory, filename);
                if (!File.Exists(path) || !byteArrayCompare(contentBytes, File.ReadAllBytes(path)))
                {
                    File.WriteAllBytes(path, contentBytes);
                }
                return path;
            }
    
            [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern int memcmp(byte[] b1, byte[] b2, long count);
    
            public static bool byteArrayCompare(byte[] b1, byte[] b2)
            {
                // Validate buffers are the same length.
                // This also ensures that the count does not exceed the length of either buffer.  
                return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
            }
    
            public static byte[] imageToPngByteArray(Image image)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
