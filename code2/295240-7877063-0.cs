    using System.IO.Packaging; // Assembly WindowsBase.dll
      :
         static void Main(string[] args)
         {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String file = Path.Combine(path, "Doc1.docx");
            Package docx = Package.Open(file, FileMode.Open, FileAccess.Read);
            String subject = docx.PackageProperties.Subject;
            String title = docx.PackageProperties.Title;
            docx.Close();
         }
