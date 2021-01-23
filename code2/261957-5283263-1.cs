            public static String[] SplitPath(string path)
            {
                String[] pathSeparators = new String[] 
                { 
                    Path.DirectorySeparatorChar.ToString()
                };
                return path.Split(pathSeparators, StringSplitOptions.RemoveEmptyEntries);
            }
