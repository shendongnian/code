    using System;
    using System.IO;
    using System.IO.Packaging;
    
    namespace ZipSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                AddFileToZip("Output.zip", @"C:\Windows\Notepad.exe");
                AddFileToZip("Output.zip", @"C:\Windows\System32\Calc.exe");
            }
      
            private static void AddFileToZip(string zipFilename, string fileToAdd)
            {
                using (Package zip = System.IO.Packaging.Package.Open(zipFilename, FileMode.OpenOrCreate))
                {
                    string destFilename = ".\\" + Path.GetFileName(fileToAdd);
                    Uri uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));
                    if (zip.PartExists(uri))
                    {
                        zip.DeletePart(uri);
                    }
                    PackagePart part = zip.CreatePart(uri, "",CompressionOption.Normal);
                    using (FileStream fileStream = new FileStream(fileToAdd, FileMode.Open, FileAccess.Read))
                    {
                        using (Stream dest = part.GetStream())
                        {
                            fileStream.CopyTo(dest);
                        }
                    }
                }
            }              
        }
    }
