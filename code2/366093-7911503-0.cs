    using System;
    using System.IO;
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(GetTopRelativeFolderName(@"foo\bar\abc.txt")); // prints 'foo'
            Console.WriteLine(GetTopRelativeFolderName("bar/foo/foobar")); // prints 'bar'
            Console.WriteLine(GetTopRelativeFolderName("C:/full/rooted/path")); // ** throws
        }
        private static string GetTopRelativeFolderName(string relativePath)
        {
            if (Path.IsPathRooted(relativePath))
            {
                throw new ArgumentException("Path is not relative.", "relativePath");
            }
            FileInfo fileInfo = new FileInfo(relativePath);
            DirectoryInfo workingDirectoryInfo = new DirectoryInfo(".");
            string topRelativeFolderName = string.Empty;
            DirectoryInfo current = fileInfo.Directory;
            bool found = false;
            while (!found)
            {
                if (current.FullName == workingDirectoryInfo.FullName)
                {
                    found = true;
                }
                else
                {
                    topRelativeFolderName = current.Name;
                    current = current.Parent;
                }
            }
            return topRelativeFolderName;
        }
    }
