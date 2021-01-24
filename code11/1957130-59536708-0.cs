using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
namespace Renamer
{
    class Program
    {
        static void Main(string[] args)
        {
            using var archive = new ZipArchive(File.Open(@"<Your File>.zip", FileMode.Open, FileAccess.ReadWrite), ZipArchiveMode.Update);
            var entries = archive.Entries.ToArray();
            foreach (ZipArchiveEntry entry in entries)
            {
                //If ZipArchiveEntry is a directory it will have its FullName property ending with "/" (e.g. "some_dir/") 
                //and its Name property will be empty string ("").
                if (!string.IsNullOrEmpty(entry.Name))
                {
                    var newEntry = archive.CreateEntry($"{entry.FullName.Replace(entry.Name, $"{RandomString(10, false)}{Path.GetExtension(entry.Name)}")}");
                    using (var a = entry.Open())
                    using (var b = newEntry.Open())
                        a.CopyTo(b);
                    entry.Delete();
                }
            }
        }
        //To Generate random name for the file
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
