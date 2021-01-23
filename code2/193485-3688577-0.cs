    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    class ITunesChecker
    {
        static void Main(string[] args)
        {
            // retrieve file names
            string baseFolder = @"E:\My Music\";
            string[] filesM4a = Directory.GetFiles(baseFolder, "*.m4a", SearchOption.AllDirectories);
            string[] filesMp3 = Directory.GetFiles(baseFolder, "*.mp3", SearchOption.AllDirectories);
            string[] files = new string[filesM4a.Length + filesMp3.Length];
            Array.Copy(filesM4a, 0, files, 0, filesM4a.Length);
            Array.Copy(filesMp3, 0, files, filesM4a.Length, filesMp3.Length);
           
            // convert to the format used by iTunes
            for (int i = 0; i < files.Length; i++)
            {
                Uri uri = null;
                if (Uri.TryCreate(files[i], UriKind.Absolute, out uri))
                {
                    files[i] = uri.AbsoluteUri.Replace("file:///", "file://localhost/");
                }
            }
    
            // read the files from iTunes library.xml
            XDocument library = XDocument.Load(@"E:\My Music\iTunes\iTunes Music Library.xml");
            var q = from node in library.Document.Descendants("string")
                    where node.ElementsBeforeSelf("key").Where(n => n.Parent == node.Parent).Last().Value == "Location"
                    select node.Value;
    
            // do the set operations you are interested in
            var missingInLibrary = files.Except(q, StringComparer.InvariantCultureIgnoreCase);
            var missingInFileSystem = q.Except(files, StringComparer.InvariantCultureIgnoreCase);
            var presentInBoth = files.Intersect(q, StringComparer.InvariantCultureIgnoreCase);
        }
    }
