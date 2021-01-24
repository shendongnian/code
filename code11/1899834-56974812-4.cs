    public async Task<List<string>> ProcessConvertInfoAsync(string[] csvfiles, string destiPath)
    {
        return await Task.Run(() =>
        {
            foreach (string filePath in csvfiles)
            {
                //Progressbar value
                int i = Array.IndexOf(csvfiles, filePath);
    
                //Passing value to Delegate
                UpdateProgress(i++);
            }
            return csvfiles.ToList();
        });
    }
