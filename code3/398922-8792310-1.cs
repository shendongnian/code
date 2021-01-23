    // Warning! To keep this code clean I
    // left out all error handling. Use at own risk.
    //
    // requires using System.Linq;
    private int VersionSortingValue(string s)
    {
        int res = 0;
        string[] items = s.Split('.', '-');
        if(items.Length != 3)
        {
            res = 1;
        }
        return (int.Parse(items[0]) << 1) + res;
    }
    // actual sorting:
    var prefix = "UpdateTo";
    Func<string, string> getVersion = 
        x => x.Substring(x.LastIndexOf(prefix) + prefix.Length);
    files = files
        .OrderBy(x => VersionSortingValue(getVersion(x))
        .ThenBy(x => getVersion(x))
        .ToList();
