    public static class ZipArchiveEntryExt {
        public static IEnumerable<string> GetLines(this ZipArchiveEntry e) {
            using (var stream = e.Open()) {
                using (var sr = new StreamReader(stream)) {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        yield return line;
                }
            }
        }
    }
    
    public static class ZipArchiveExt {
        public static IEnumerable<string> FilesContain(this ZipArchive arch, string target) {
            foreach (var entry in arch.Entries.Where(e => !e.FullName.EndsWith("/")))
                if (entry.GetLines().Any(line => line.Contains(target)))
                    yield return entry.FullName;
        }
    }
