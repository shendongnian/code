    public async Task<IActionResult> GetSomeFileReallyAsync(RequestParameters p) {
        string filePath = Preprocess(p);
        byte[] data;
        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous)) {
            data = new byte[fs.Length];
            await fs.ReadAsync(data, 0, data.Length);
        }
    
        return PostProcess(data);
    }
