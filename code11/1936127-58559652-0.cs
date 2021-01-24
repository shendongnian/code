C#
public class FlushingTextTraceListener : TextWriterTraceListener
{
    public FlushingTextTraceListener(string filePath)
    {
        FilePath = filePath;
    }
    public String FilePath { get; set; }
    public override void Write(string message)
    {
        using (var sw = new StreamWriter(File.Open(FilePath, FileMode.Create, 
            FileAccess.Write, FileShare.Read)))
        {
            sw.Write(message);
        }
    }
    public override void WriteLine(string message)
    {
        using (var sw = new StreamWriter(File.Open(FilePath, FileMode.Create, 
            FileAccess.Write, FileShare.Read)))
        {
            sw.WriteLine(message);
        }
    }
}
Usage:
C#
_dbgTraceListener = new FlushingTextTraceListener("C:\\temp\\myLog.txt");
Debug.Listeners.Add(_dbgTraceListener);
<hr/>
##Appendix A
Other things I tried, mentioned in detail because I may have screwed up one or all of them. For testing, I put a button on a WPF window and in the button's click method, I traced a line of text:
    Trace.WriteLine(DateTime.Now);
In that event handler, after that line, I tried a few different things. You aren't looking for a wrapper method around Trace.WriteLine(), of course, but I figured if one of these worked there would be some way to use it cleanly. 
These didn't cause a filesystem event, but they didn't throw an exception:
    Trace.Flush();
    _dbgTraceListener.Flush();
    _dbgOutputWriter.Flush();
I tried "touching" the file by setting last access time in two ways, but got an exception (System.IO.IOException: 'The process cannot access the file 'C:\temp\myLog.txt' because it is being used by another process.')
    new FileInfo("C:\\temp\\myLog.txt").LastWriteTime = DateTime.UtcNow;
    File.SetLastWriteTimeUtc("C:\\temp\\myLog.txt", DateTime.UtcNow);
I found that I got an access event when I typed `type c:\temp\myLog.txt` in cmd.exe, so I tried opening the file readonly in C# and promptly disposing it. I did not try launching a cmd.exe process with `type myLog.txt` or `type nul > myLog.txt`, because that seemed like a much sillier solution than the one above that worked. 
    using (var f = File.Open("C:\\temp\\myLog.txt", FileMode.Open, 
                             FileAccess.Read, FileShare.Read))
        ;
And
    using (var f = File.OpenRead("C:\\temp\\myLog.txt"))
        ;
I got the same exception as above in both cases. For this test, I created _dbgOutputWriter with the `FileShare.ReadWrite` flag as follows:
    _dbgOutputWriter = new StreamWriter(File.Open("C:\\temp\\myLog.txt", FileMode.Create, 
                                        FileAccess.Write, FileShare.ReadWrite));
[`FileShare.ReadWrite`](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileshare#fields):
> Allows subsequent opening of the file for reading or writing. If this flag is not specified, any request to open the file for reading or writing (by this process or another process) will fail until the file is closed. However, even if this flag is specified, **additional permissions might still be needed to access the file.**
Emphasis mine. Perhaps that just means the user must have access to the file to begin with. 
I added `NotifyFilters.LastAccess` to the `NotifyFilter` on the FileSystemWatcher, but that made no difference that I noticed. 
