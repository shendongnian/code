    public void cleanUp()
        {
            var cFiles = Directory.GetFiles(@"c:\MyData","*.*",SearchOption.AllDirectories);
            var fFiles = Directory.GetFiles(@"e:\projects\massdata","*.*",SearchOption.AllDirectories);
            Func<string, string, Tuple<string, long>> keySelector = (path, root) =>
                new Tuple<string, long>(path.Replace(root, ""), new FileInfo(path).Length);
            foreach (var file in cFiles.Join(fFiles, f => keySelector(f,@"e:\projects\massdata"), c => keySelector(c,@"c:\MyData"), (c, f) => c))
            {
                File.Delete(file);
            }
        }
