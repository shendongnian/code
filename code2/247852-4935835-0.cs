    public static Task<string> MakeZipAsync(string [] files,bool IsOriginal) 
    {
        return Task.Factory.StartNew( () =>
           {
               return Makezipfile(files, IsOriginal);
           });
    }
