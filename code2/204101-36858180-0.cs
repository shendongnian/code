     public void Main()
            {
                var path = @"/folder1/folder2/image.jpg";
                //is valid path?
                if (!System.IO.Path.GetInvalidPathChars().Any(c => path.Contains(c.ToString())))
                {
    
                    if (IsAbsolutePhysicalPath(path))
                    {
                        // This is the full path
                    }
                    else
                    {
                        // This is not the full path
                    }
    
                }
            }
            private bool IsAbsolutePhysicalPath(string path)
            {
                if (path == null || path.Length < 3)
                    return false;
    
                // e.g c:\foo
                if (path[1] == ':' && IsDirectorySeparatorChar(path[2]))
                    return true;
    
                // e.g \\server\share\foo or //server/share/foo
                return IsUncSharePath(path);
            }
            private bool IsDirectorySeparatorChar(char ch)
            {
                return (ch == '\\' || ch == '/');
            }
    
            private bool IsUncSharePath(string path)
            {
                // e.g \\server\share\foo or //server/share/foo
                if (path.Length > 2 && IsDirectorySeparatorChar(path[0]) && IsDirectorySeparatorChar(path[1]))
                    return true;
                return false;
    
            }
    
