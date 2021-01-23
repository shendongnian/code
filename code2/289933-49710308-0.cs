    using System;
    using System.IO;
    namespace FileSystemExample
    {
    class FileExample
    {
        public static void Main()
        {
            try
            {
                string OriginalFile = path+"test.tmp";
                string FileToReplace = path+"test2.tmp";
                string BackUpOfFileToReplace = path+"test2.tmp.bac";
                Console.WriteLine("Move the contents of " + OriginalFile + " into " + FileToReplace + ", delete " + OriginalFile +
                                   ", and create a backup of " + FileToReplace + ".");
                // Replace the file.
                ReplaceFile(@OriginalFile, @FileToReplace, @BackUpOfFileToReplace);
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
        // Move a file into another file, delete the original, and create a backup of the replaced file.
        public static void ReplaceFile(string FileToMoveAndDelete, string FileToReplace, string BackupOfFileToReplace)
        {
            File.Replace(FileToMoveAndDelete, FileToReplace, BackupOfFileToReplace, false);
        }
    }
}
