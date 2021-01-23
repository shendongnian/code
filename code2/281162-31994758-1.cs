        public string ProcessFolderDash(string path)
        {
            int dotCount = path.Split('/').Length - 1; // Gets the count of slashes
            int dotCountLoop = 1; // Placeholder
            string[] absolutepath = path.Split('/');
            for (int i = 0; i < absolutepath.Length; i++)
            {
                if (dotCountLoop <= dotCount) // check to see if its a file
                {
                    absolutepath[i] = absolutepath[i].Replace("-", "_");
                }
                dotCountLoop++;
            }
            return String.Join("/", absolutepath);
        }
