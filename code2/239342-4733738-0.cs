    using ICSharpCode.SharpZipLib.Zip;
    using ICSharpCode.SharpZipLib.Checksums;
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    using System.Text.RegularExpressions;
    
    namespace Zip
    {
        /// <summary>
        /// Uses Sharpziplib so as to create a non flat zip archive
        /// </summary>
        public abstract class ZipManager
        {   
    	/// <summary>
            /// will zip directory .\toto as .\toto.zip
            /// </summary>
            /// <param name="stDirToZip"></param>
            /// <returns></returns>
            public static string CreateZip(string stDirToZip)
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(stDirToZip);
                    string stZipPath = di.Parent.FullName + "\\" + di.Name + ".zip";
    
                    CreateZip(stZipPath, stDirToZip);
    
                    return stZipPath;
                }
                catch (Exception)
                {
                    throw;
                }
            }
    	
            /// <summary>
            /// Main method
            /// </summary>
            /// <param name="stZipPath">path of the archive wanted</param>
            /// <param name="stDirToZip">path of the directory we want to create, without ending backslash</param>
            public static void CreateZip(string stZipPath, string stDirToZip)
            {
                try
                {
    		//Sanitize inputs
                    stDirToZip = Path.GetFullPath(stDirToZip);
                    stZipPath = Path.GetFullPath(stZipPath);
    		
                    Console.WriteLine("Zip directory " + stDirToZip);
    
                    //Recursively parse the directory to zip 
                    Stack<FileInfo> stackFiles = DirExplore(stDirToZip);
    
                    ZipOutputStream zipOutput = null;
    
                    if (File.Exists(stZipPath))
                        File.Delete(stZipPath);
    
                    Crc32 crc = new Crc32();
                    zipOutput = new ZipOutputStream(File.Create(stZipPath));
                    zipOutput.SetLevel(6); // 0 - store only to 9 - means best compression
    
                    Console.WriteLine(stackFiles.Count + " files to zip.\n");
    
                    int index = 0;
                    foreach (FileInfo fi in stackFiles)
                    {
                        ++index;
                        int percent = (int)((float)index / ((float)stackFiles.Count / 100));
                        if (percent % 1 == 0)
                        {
                            Console.CursorLeft = 0;
                            Console.Write(_stSchon[index % _stSchon.Length].ToString() + " " + percent + "% done.");
                        }
                        FileStream fs = File.OpenRead(fi.FullName);
    
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
    
                        //Create the right arborescence within the archive
                        string stFileName = fi.FullName.Remove(0,stDirToZip.Length + 1);
                        ZipEntry entry = new ZipEntry(stFileName);
    
                        entry.DateTime = DateTime.Now;
    
                        // set Size and the crc, because the information
                        // about the size and crc should be stored in the header
                        // if it is not set it is automatically written in the footer.
                        // (in this case size == crc == -1 in the header)
                        // Some ZIP programs have problems with zip files that don't store
                        // the size and crc in the header.
                        entry.Size = fs.Length;
                        fs.Close();
    
                        crc.Reset();
                        crc.Update(buffer);
    
                        entry.Crc = crc.Value;
    
                        zipOutput.PutNextEntry(entry);
    
                        zipOutput.Write(buffer, 0, buffer.Length);
                    }
                    zipOutput.Finish();
                    zipOutput.Close();
                    zipOutput = null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        static private Stack<FileInfo> DirExplore(string stSrcDirPath)
            {
                try
                {
                    Stack<DirectoryInfo> stackDirs = new Stack<DirectoryInfo>();
                    Stack<FileInfo> stackPaths = new Stack<FileInfo>();
    
                    DirectoryInfo dd = new DirectoryInfo(Path.GetFullPath(stSrcDirPath));
    
                    stackDirs.Push(dd);
                    while (stackDirs.Count > 0)
                    {
                        DirectoryInfo currentDir = (DirectoryInfo)stackDirs.Pop();
    
                        try
                        {
                            //Process .\files
                            foreach (FileInfo fileInfo in currentDir.GetFiles())
                            {
                                  stackPaths.Push(fileInfo);
                            }
    
                            //Process Subdirectories
                            foreach (DirectoryInfo diNext in currentDir.GetDirectories())
                                stackDirs.Push(diNext);
                        }
                        catch (Exception)
                        {//Might be a system directory
                        }
                    }
                    return stackPaths;
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            private static char[] _stSchon = new char[] { '-', '\\', '|', '/' };
    }
