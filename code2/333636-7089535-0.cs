    using System;
    using System.Collections;
    using System.IO;
    using ICSharpCode.SharpZipLib.Zip;
    namespace ENSI.Releaser.Code
    {
        public class ZipUtility
        {
            public void ZipFiles(string inputFolderPath, string outputPathAndFile, string     password)
        {
            ArrayList ar = GenerateFileList(inputFolderPath); // generate file list
            int trimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
            // find number of chars to remove     // from orginal file path
            trimLength += 1; //remove '\'
            FileStream ostream;
            byte[] obuffer;
            string outPath = inputFolderPath + @"\" + outputPathAndFile;
            var oZipStream = new ZipOutputStream(File.Create(outPath)); // create zip stream
            if (!string.IsNullOrEmpty(password))
                oZipStream.Password = password;
            oZipStream.SetLevel(9); // maximum compression
            ZipEntry oZipEntry;
            foreach (string fil in ar) // for each file, generate a zipentry
            {
                oZipEntry = new ZipEntry(fil.Remove(0, trimLength));
                oZipStream.PutNextEntry(oZipEntry);
                if (!fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                {
                    ostream = File.OpenRead(fil);
                    obuffer = new byte[ostream.Length];
                    ostream.Read(obuffer, 0, obuffer.Length);
                    oZipStream.Write(obuffer, 0, obuffer.Length);
                }
            }
            oZipStream.Finish();
            oZipStream.Close();
        }
        private ArrayList GenerateFileList(string dir)
        {
            var fils = new ArrayList();
            bool Empty = true;
            foreach (string file in Directory.GetFiles(dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }
            if (Empty)
            {
                if (Directory.GetDirectories(dir).Length == 0)
                // if directory is completely empty, add it
                {
                    fils.Add(dir + @"/");
                }
            }
            foreach (string dirs in Directory.GetDirectories(dir)) // recursive
            {
                foreach (object obj in GenerateFileList(dirs))
                {
                    fils.Add(obj);
                }
            }
            return fils; // return file list
        }
        public void UnZipFiles(string zipPathAndFile, string outputFolder, string password, bool deleteZipFile)
        {
            var s = new ZipInputStream(File.OpenRead(zipPathAndFile));
            if (!string.IsNullOrEmpty(password))
                s.Password = password;
            ZipEntry theEntry;
            string tmpEntry = String.Empty;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = outputFolder;
                string fileName = Path.GetFileName(theEntry.Name);
                // create directory 
                if (directoryName != "")
                {
                    Directory.CreateDirectory(directoryName);
                }
                if (fileName != String.Empty)
                {
                    if (theEntry.Name.IndexOf(".ini") < 0)
                    {
                        string fullPath = directoryName + "\\" + theEntry.Name;
                        fullPath = fullPath.Replace("\\ ", "\\");
                        string fullDirPath = Path.GetDirectoryName(fullPath);
                        if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);
                        FileStream streamWriter = File.Create(fullPath);
                        int size = 2048;
                        byte[] data = new byte[size];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
            }
            s.Close();
            if (deleteZipFile)
                File.Delete(zipPathAndFile);
        }
    }
    }
