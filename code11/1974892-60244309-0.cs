using System.Linq;
using System.Collections.Generic;
using System.IO;
public async Task<ActionResult> Items( Int32? page )
{
    const String path = @"C:\Users\MyUser\Desktop\items-json\";
    const Int32 pageSize = 50;
    Int32 pageIndex = ( ( page ?? 1 ) - 1 ); // 0-based indexing!
    
    IReadOnlyList<FileInfo> files = new DirectoryInfo( path ).GetFiles("*.json");
    
    List<FileInfo> filesToRead = files
        .OrderBy( fi => fi.Name, StringComparer.OrdinalIgnoreCase )
        .Skip( pageSize * pageIndex )
        .Take( pageSize )
        .ToList();
    IReadOnlyList<ItemModel> items = await ReadJsonFilesAsync<ItemModel>( filesToRead ).ConfigureAwait(false);
   
    return this.View( items );
}
private static async Task<IReadOnlyList<T>> ReadJsonFilesAsync<T>( IEnumerable<FileInfo> jsonFiles )
{
    // Asynchronously read from all the files at once and let Windows' Overlapped-IO take care of it:
    List<Task<T>> tasks = jsonFiles
        .Select( fi => ReadJsonFileAsync<T>( fi.FullName ) )
        .ToList();
    T[] items = await Task.WhenAll( tasks ).ConfigureAwait(false);
    return items;
}
private static async Task<T> ReadJsonFileAsync<T>( String path )
{
    const Int32 asyncFileStreamBufferSize = 1 * 1024 * 1024; // Adjust this to be a reasonably sized multiple of 4096 that's at least larger than any file you'll process.
    using( FileStream fs = new FileStream( path: path, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.Read, bufferSize: asyncFileStreamBufferSize, useAsync: true )
    using( StreamReader rdr = new StreamReader( fs ) )
    {
        // Annoyingly, JsonTextReader and JsonSerializer doesn't support true async deserialization - but the entire file will be buffered into a string anyway so it's moot - so we great perf at the cost of somewhat higher memory usage.
        String fileText = await rdr.ReadToEndAsync().ConfigureAwait(false);
        return JsonConvert.DeserializeObject<T>( fileText );
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/using-async-for-file-access
  [2]: https://docs.microsoft.com/en-us/windows/win32/sync/synchronization-and-overlapped-input-and-output
