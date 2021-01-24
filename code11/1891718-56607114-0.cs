 c#
using System;
using System.IO;
namespace FileWatcherExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\example";
            MonitorDirectory(path);
            Console.ReadKey();
        }
        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.Deleted += (o,s) => Console.WriteLine("File deleted: {0}", e.Name);
            fileSystemWatcher.EnableRaisingEvents = true;
        }
    }
}
The file watcher allows for create, modify and delete events allowing you to permanently get real time updates on changes to a folder or file.
