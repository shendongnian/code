var fileName = "a.zip";
var src = "c:\\tmp\\src";
var dst = "c:\\tmp\\dst";
using (FileSystemWatcher watcher = new FileSystemWatcher())
{
    watcher.Path = dst;
    void OnChanged(object source, FileSystemEventArgs e) =>
            Console.WriteLine($"{DateTime.Now:O}, OnChanged, file: {e.FullPath} {e.ChangeType}, size: {new System.IO.FileInfo(Path.Combine(dst,fileName)).Length}");
    void OnCreated(object source, FileSystemEventArgs e) =>
            Console.WriteLine($"{DateTime.Now:O}, OnCreated, file: {e.FullPath} {e.ChangeType}, size: {new System.IO.FileInfo(Path.Combine(dst,fileName)).Length}");
    watcher.NotifyFilter = NotifyFilters.Size
                        | NotifyFilters.DirectoryName
                        | NotifyFilters.Attributes
                        | NotifyFilters.Size
                        | NotifyFilters.LastWrite
                        | NotifyFilters.LastAccess
                        | NotifyFilters.CreationTime
                        | NotifyFilters.Security
                        ;
    
    watcher.Changed += OnChanged;
    watcher.Created += OnCreated;
    // Begin watching.
    watcher.EnableRaisingEvents = true;
    Console.WriteLine($"{DateTime.Now:O} Let's start copying");
    var t = Task.Run(() => {
        Console.WriteLine($"{DateTime.Now:O} Copy start");
        System.IO.File.Copy(Path.Combine(src, fileName), Path.Combine(dst,fileName), overwrite: false);
        Console.WriteLine($"{DateTime.Now:O} Copy end");
    });
    await t;
    Console.ReadLine();
}
2019-11-04T10:54:26.4737696+10:00 Let's start copying
2019-11-04T10:54:26.4972070+10:00 Copy start
2019-11-04T10:54:26.5093223+10:00, OnChanged, file: c:\tmp\dst\a.zip Changed, size: 1232583046
2019-11-04T10:54:26.5195866+10:00, OnChanged, file: c:\tmp\dst\a.zip Changed, size: 1232583046
2019-11-04T10:54:30.6444434+10:00 Copy end
2019-11-04T10:54:30.5599570+10:00, OnChanged, file: c:\tmp\dst\a.zip Changed, size: 1232583046
# B. Zero length
You already have one possible answer: 
> I'm experiencing an issue where sometime the file length is zero.
You could check the length of the file and wait until it's not zero any more. 
----
While this is not strictly copying, here is a view of a folder during Firefox downloading a file.
[![enter image description here][1]][1]
04/11/2019  10:01    <DIR>          .
04/11/2019  10:01    <DIR>          ..
04/11/2019  10:01                 0 SSMS-Setup-ENU.exe
04/11/2019  10:01        56,512,149 SSMS-Setup-ENU.exe.part
               2 File(s)     56,512,149 bytes
Here is a the same file being downloaded by Internet Explorer.
04/11/2019  10:04    <DIR>          .
04/11/2019  10:04    <DIR>          ..
04/11/2019  10:04                 0 SSMS-Setup-ENU.exe.pz0u92s.partial
               1 File(s)              0 bytes
