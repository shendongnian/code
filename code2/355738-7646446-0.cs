    private string Compare()
        {
            string[] compareAgainst = File.ReadAllLines("[file_path]");
            string[] row = new string[] { "name1", "name2", "name3", "name4", };
            string result = string.Empty;
            foreach(string name in compareAgainst)
            {
                if (row.Contains(name))
                    result = String.Format(result + " {0}", name);
            }
            return result;
        }
