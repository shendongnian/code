    public void cleanUp()
            {
                var cFiles = Directory.GetFiles(@"c:\MyData","*.*",SearchOption.AllDirectories);
                var fFiles = Directory.GetFiles(@"e:\projects\massdata","*.*",SearchOption.AllDirectories);
                foreach (var file in cFiles.Join(fFiles, Path.GetFileName, Path.GetFileName, (c, f) => c))
                {
                    File.Delete(file);
                }
            }
