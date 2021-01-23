    using System;
    
    class Program {
        static void Main(string[] args) {
            var type = Type.GetTypeFromProgID("Scripting.FileSystemObject");
            dynamic obj = Activator.CreateInstance(type);
            dynamic win = obj.GetFolder("c:/windows");
            foreach (dynamic subwin in win.SubFolders) {
                Console.WriteLine(subwin.Name);
            }
            Console.ReadLine();
        }
    }
