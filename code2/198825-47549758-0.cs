    public static FileInfo[] GetFiles(DirectoryInfo dir, string searchPattern, SearchOption searchOption)
        {
            string[] searchPatterns = searchPattern.Split('|');
            FileInfo[] fileinfos=null;
            foreach (string sp in searchPatterns)
            {
                FileInfo[] newFiles = dir.GetFiles(sp, searchOption);
                if (fileinfos == null)
                {
                    fileinfos = newFiles;
                }
                else
                {
                    if (newFiles.Length > 0)
                    {
                        fileinfos = (FileInfo[])fileinfos.Concat(newFiles).ToArray();
                    }
                }
            }
            return fileinfos;
        }
