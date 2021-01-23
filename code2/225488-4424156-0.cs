    private static IEnumerable<string> DirectoryGetFiles(string strDirName, SearchOption varOption) {
    var extensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".zip", ".sfv" };
         extensions.UnionWith(Enumerable.Range(1, 999).Select(i => String.Format(".{0:000}", i)));
         extensions.UnionWith(Enumerable.Range(1, 99).Select(i => String.Format(".r{0:00}", i)));
         extensions.UnionWith(Enumerable.Range(1, 99).Select(i => String.Format(".s{0:00}", i)));
         extensions.UnionWith(Enumerable.Range(1, 99).Select(i => String.Format(".t{0:00}", i)));
         return Directory.EnumerateFiles(strDirName, "*.*", varOption).Where(p => extensions.Contains(Path.GetExtension(p))).ToList();
    }
