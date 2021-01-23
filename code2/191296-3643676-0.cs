    public List<FileData> RecurseDirectory(string directory, int level, out int files, out int folders)
            {
                IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
                //long size = 0;
                files = 0;
                folders = 0;
                WIN32_FIND_DATA findData;
                List<FileData> list = new List<FileData>();
    
                IntPtr findHandle;
    
                // add global escape chars if not present.
                if (directory.StartsWith(@"\\?\"))
                {
                    findHandle = FindFirstFile(directory + @"\*", out findData);
                }
                else
                {
                    findHandle = FindFirstFile(@"\\?\" + directory + @"\*", out findData);
                }
    
                
                if (findHandle != INVALID_HANDLE_VALUE)
                {
                    //if file exists:
    
    
                    do
                    {
                        if ((findData.dwFileAttributes & FileAttributes.Directory) != 0)
                        {
                            //if it's a directory:
    
                            if (findData.cFileName != "." && findData.cFileName != "..")
                            {
                                //increment folder counter.
                                folders++;
    
                                int subfiles, subfolders;
                                string subdirectory = directory + (directory.EndsWith(@"\") ? "" : @"\") +
                                    findData.cFileName;
                                //Console.WriteLine("Dir:" + subdirectory);
    
                                //add it to list
                                String path = subdirectory;
                                FileData tempFileData = new FileData();
                                tempFileData.path = path;
                                tempFileData.fileProperties = findData;
                                list.Add(tempFileData);
    
                                //allows -1 to do complete search.
                                if (level != 0)
                                {
                                    //recurse through to next subfolder
                                    list.AddRange(RecurseDirectory(subdirectory, level - 1, out subfiles, out subfolders));
    
                                    folders += subfolders;
                                    files += subfiles;
                                }
                            }
                        }
                        else
                        {
                            // File
                            files++;
                            string subfile = directory + (directory.EndsWith(@"\") ? "" : @"\") +
                                    findData.cFileName;
                            //Console.WriteLine("File:" + subfile);
                            //list.Add("File:" + subfile);
                            String path = subfile;
                            FileData t = new FileData();
                            t.path = path;
                            t.fileProperties = findData;
                            list.Add(t);
    
                            //size += (long)findData.nFileSizeLow + (long)findData.nFileSizeHigh * 4294967296L;
                        }
                    }
                    while (FindNextFile(findHandle, out findData));
                    FindClose(findHandle);
    
                }
    
                return list;
            }
