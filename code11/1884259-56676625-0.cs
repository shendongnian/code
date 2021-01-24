 csharp
public class HeaderChecker : IDisposable
{
    private readonly string _folderPath;
    private readonly int _headersCount;
    private string _lockedFile;
    private readonly List<IEnumerator<string>> _files = new List<IEnumerator<string>>();
    public HeaderChecker(string folderPath, int headersCount)
    {
        _folderPath = folderPath;
        _headersCount = headersCount;
    }
    public string LockedFile => _lockedFile;
    public bool CheckFiles()
    {
        _lockedFile = null;
        if (!TryOpenFiles())
        {
            return false;
        }
        if (_files.Count == 0)
        {
            return true; // Not sure what to return here.
        }
        for (int i = 0; i < _headersCount; i++)
        {
            if (!_files[0].MoveNext()) return false;
            string currentLine = _files[0].Current;
            for (int fileIndex = 1; fileIndex < _files.Count; fileIndex++)
            {
                if (!_files[fileIndex].MoveNext()) return false;
                if (_files[fileIndex].Current != currentLine) return false;
            }
        }
        return true;
    }
    private bool TryOpenFiles()
    {
        bool result = true;
        foreach (string file in Directory.EnumerateFiles(_folderPath))
        {
            try
            {
                _files.Add(File.ReadLines(file).GetEnumerator());
            }
            catch
            {
                _lockedFile = file;
                result = false;
                break;
            }
        }
        if (!result)
        {
            DisposeCore(); // Close already opened files.
        }
        return result;
    }
    private void DisposeCore()
    {
        foreach (var item in _files)
        {
            try
            {
                item.Dispose();
            }
            catch
            {
            }
        }
        _files.Clear();
    }
    public void Dispose()
    {
        DisposeCore();
    }
}
// Usage
using (var checker = new HeaderChecker(folderPath, headersCount))
{
    if (!checker.CheckFiles())
    {
        if (checker.LockedFile is null)
        {
            // Error while opening files.
        }
        else
        {
            // Headers do not match.
        }
    }
}
I also removed `.Select()` and `.Distinct()` when checking the lines. The first just iterates over the `enumerators` array - the same as `foreach` above it, so you are enumerating this array twice. Then creates a new list of lines and `.Distinct()` enumerates over it.
