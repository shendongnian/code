        private static IEnumerable<FileInfo> FindFileSpecs(IEnumerable<string> specs, bool recurse)
        {
            foreach (var spec in specs)
            {
                if (!Verify(spec))
                    continue;
                var info = new DirectoryInfo(spec);
                if ((info.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    foreach (var s in info.GetFiles("*.cs", SearchOption.TopDirectoryOnly))
                        yield return s;
                    if (recurse)
                        foreach (var s in FindFileSpecs(info.GetDirectories().Select(d => d.FullName), recurse))
                            yield return s;
                }
                else
                    yield return new FileInfo(info.FullName);
            }
        }
        private static bool Verify(string spec)
        {
            try { return new FileInfo(spec).Exists || new DirectoryInfo(spec).Exists; }
            catch (Exception e)
            {
                Console.Error.WriteLine(String.Format("Invalid file/folder specification '{0}': {1}", spec, e.Message));
                return false;
            }
        }
