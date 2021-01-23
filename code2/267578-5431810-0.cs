    using System;
    using System.IO;
    using System.IO.Packaging; // Assembly WindowsBase.dll
    namespace ConsoleApplication16
    {
      class Program
      {
         static void Main(string[] args)
         {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String file = Path.Combine(path, "Doc1.docx");
            Package docx = Package.Open(file, FileMode.Open, FileAccess.Read);
            String subject = docx.PackageProperties.Subject;
            String title = docx.PackageProperties.Title;
            docx.Close();
         }
      }
    }
