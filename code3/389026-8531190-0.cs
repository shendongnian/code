    public string[] getExtensions(string input) {
        if (string.isNullOrEmpty(input) || input.indexOf('|') == -1) {
            return null;
        }
        else {
            List<string> returnValue = new List<string>();
            string[] parts = input.Split('|')
            for(int x = 1; x < input.Length; x+=2) {
                foreach(string extension in parts[x].Split(',')) {
                    returnValue.Add(extension);
                }
            }
            return returnValue.ToArray();
        }
    }
