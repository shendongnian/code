    public static long Seek(string file, long position, string searchString)
            {
                //open filestream to perform a seek
                using (System.IO.FileStream fs =
                            System.IO.File.OpenRead(file))
                {
                    fs.Position = position;
                    return Seek(fs, searchString);
                }
            }
