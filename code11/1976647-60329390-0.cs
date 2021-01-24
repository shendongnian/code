    public static async Task Save() 
    {
        using (var file = File.CreateText(_studentRepositoryPath))
        {
            await file.WriteAsync(JsonSerializer.Serialize(studentsList));
        }
    }
