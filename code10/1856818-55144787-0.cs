    public static bool FileExists(string path, int timeout = 2000)
    {
        Task<bool> task = Task.Run(() => File.Exists(path));
        return task.Wait(timeout)) && task.Result;
    }
    
