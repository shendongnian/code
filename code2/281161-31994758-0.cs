        public string ProcessFolderDash(string path)
        {
            string[] absolutepath = path.Split('/');
            for (int i = 0; i < absolutepath.Length; i++)
            {
                if (!absolutepath[i].Contains(".")) // detects if we are at the end where an extension exists :)
                {
                    absolutepath[i] = absolutepath[i].Replace("-", "_");
                }
            }
    
            return String.Join("/", absolutepath);
        }
