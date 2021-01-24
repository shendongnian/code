C#
    List<string> GetDirectoriesRecursive (string parent)
    {
        var directories = new List<string>();
        GetDirectoriesRecursive (directories, parent);
        return directories;
    }
    
    void GetDirectoriesRecursive (List<string> directories, string parent)
    {
        directories.Add (parent);
        foreach (string child in GetAuthorizedDirectories (parent))
            GetDirectoriesRecursive (directories, child);
    }
    
    string[] GetAuthorizedDirectories (string dir)
    {
        try { return Directory.GetDirectories (dir); }
        catch (UnauthorizedAccessException) { return new string[0]; }
    }
    
    string[] GetAuthorizedFiles (string dir)
    {
        try { return Directory.GetFiles (dir); }
        catch (UnauthorizedAccessException) { return new string[0]; }
    }
Then, to get the big files:
C#
     var bigFiles =
         from dir in GetDirectoriesRecursive ( @"c:\" )
         from file in GetAuthorizedFiles (dir)
         where new FileInfo (file).Length > 100000000 
         select file;
Or, to get just their directories:
C#
     var foldersWithBigFiles =
         from dir in GetDirectoriesRecursive ( @"c:\" )
         where GetAuthorizedFiles (dir).Any (f => new FileInfo (f).Length > 100000000 )
         select dir;
ANOTHER APPROACH:
C#
 string[] directories = Directory.EnumerateDirectories(@"\\testnetwork\abc$","*.*", SearchOption.AllDirectories).Catch(typeof(UnauthorizedAccessException)).ToArray();
ADDED missing part:
C#
static class ExceptionExtensions
{
public static IEnumerable<TIn> Catch<TIn>(
            this IEnumerable<TIn> source,
            Type exceptionType)
{   
    using (var e = source.GetEnumerator())
    while (true)
    {
        var ok = false;
        try
        {
            ok = e.MoveNext();
        }
        catch(Exception ex)
        {
            if (ex.GetType() != exceptionType)
                throw;
            continue;
        }
        if (!ok)
            yield break;
        yield return e.Current;
    }
}
}
