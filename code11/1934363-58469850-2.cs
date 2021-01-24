async static Task Main(string[] args)
    {
        var obj = new { Name = "Test", Age = 18 };
        Console.WriteLine(await GetJson(obj));
    }
    private static async Task<string> GetJson(object obj)
    {
        string json = string.Empty;
        using (var stream = new MemoryStream())
        {
            await JsonSerializer.SerializeAsync(stream, obj, obj.GetType());
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
    }
## Output
{"Name":"Test","Age":18}
---- 
# UPDATE
There is more to it, because the non-async version, `Serialise()` does not adhere to the same rules and desrialises the run-time type when explicitly told to serialize `<object>`. 
