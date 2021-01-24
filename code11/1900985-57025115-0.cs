csharp
using System;
using System.IO;
namespace fsw_bug_poc
{
    class Program
    {
        private static FileSystemWatcher _fileSystemWatcher;
        static void Main(string[] args)
        {
			_fileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Watched"));
			WatchForFileChanges();
			
            Console.ReadKey(false);
        }			
		private void WatchForFileChanges()
		{
			_fileChangeToken = _fileProvider.Watch("*.*");
			_fileChangeToken.RegisterChangeCallback(Notify, default);
		}
		private void Notify(object state)
		{
			Console.WriteLine("File change detected");
			WatchForFileChanges();
		}
    }
}
  [1]: https://www.nuget.org/packages/microsoft.extensions.fileproviders.physical/
