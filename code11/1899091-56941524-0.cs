C#
public Task<string> SaveFileAsync(string path, byte[] file, string fileType, CancellationToken cancellationToken = default)
When a function returns a `Task` / `Task<T>`, any exceptions it raises should be captured and placed on that returned task. The `async` keyword will do this for you.
So, you should either change the function to be `async`:
C#
public async Task<string> SaveFileAsync(string path, byte[] file, string fileType, CancellationToken cancellationToken = default)
{
    var filename = _filenameProvider.GetFilename(path, fileType);
    var fullPath = _fileSystem.Path.Combine(path, filename).Replace('/', '\\');
    try
    {
        _fileSystem.Directory.CreateDirectory(fullPath);
        // Error in the FileSystem abstraction library: https://github.com/System-IO-Abstractions/System.IO.Abstractions/issues/491
        //await _fileSystem.File.WriteAllBytesAsync(fullPath, file, cancellationToken);
        _fileSystem.File.WriteAllBytes(fullPath, file);
        return filename;
    }
    catch (Exception ex)
    {
        Log.Error(ex.Message, nameof(SaveFileAsync), _userId);
        throw;
    }
}
or place the exception on the returned task yourself:
C#
public Task<string> SaveFileAsync(string path, byte[] file, string fileType, CancellationToken cancellationToken = default)
{
    try
    {
        var filename = _filenameProvider.GetFilename(path, fileType);
        var fullPath = _fileSystem.Path.Combine(path, filename).Replace('/', '\\');
    
        _fileSystem.Directory.CreateDirectory(fullPath);
        // Error in the FileSystem abstraction library: https://github.com/System-IO-Abstractions/System.IO.Abstractions/issues/491
        //await _fileSystem.File.WriteAllBytesAsync(fullPath, file, cancellationToken);
        _fileSystem.File.WriteAllBytes(fullPath, file);
        return Task.FromResult(filename);
    }
    catch (Exception ex)
    {
        Log.Error(ex.Message, nameof(SaveFileAsync), _userId);
        return Task.FromException<string>(ex);
    }
}
