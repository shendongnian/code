        public string GetTopLevelDir(string filePath)
        {
            string temp = Path.GetDirectoryName(filePath);
            if(temp.Contains("\\"))
            {
                temp = temp.Substring(0, temp.IndexOf("\\"));
            }
            else if (temp.Contains("//"))
            {
                temp = temp.Substring(0, temp.IndexOf("\\"));
            }
            return temp;
        }
