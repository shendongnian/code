    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace FileSystemWatcherTest {
        class Program {
            static List<FileSystemWatcher> fsWatchers = new List<FileSystemWatcher>();
    
            static void Main(string[] args) {
                foreach(DriveInfo dInfo in DriveInfo.GetDrives()) {
                    InitializeWatcher(dInfo.Name);
                    Console.WriteLine("Initialized watcher for disc '" + dInfo.Name + "'");
                }
    
                Console.WriteLine("\nPress 'q' to exit");
                while (Console.Read() != 'q') ;
    
                DisposeWatchers();
            }
    
            static void DisposeWatchers() {
                foreach(FileSystemWatcher fsWatcher in fsWatchers) {
                    fsWatcher.Dispose();
                }
            }
    
            static void InitializeWatcher(string DiscPath) {
                try {
                    FileSystemWatcher fsWatcherToAdd = new FileSystemWatcher(DiscPath);
    
                    fsWatcherToAdd.NotifyFilter = NotifyFilters.LastAccess
                                         | NotifyFilters.LastWrite
                                         | NotifyFilters.FileName
                                         | NotifyFilters.DirectoryName;
    
                    fsWatcherToAdd.Created += FsWatcher_Created;
    
                    fsWatcherToAdd.IncludeSubdirectories = true;
                    fsWatcherToAdd.EnableRaisingEvents = true;
    
                    fsWatchers.Add(fsWatcherToAdd);
                } catch {
                }           
            }
    
            private static void FsWatcher_Created(object sender, FileSystemEventArgs e) {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + ": " + e.Name + " created...");
            }
        }
    }
