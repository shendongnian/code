    private static async Task<bool> SendChecksumToServer(Checksum checksum) {
        var res = await _api.GetAsync($"Checksum?assemblyName={checksum.CurrentAssembly}&checkSum={checksum.LogFileChecksum}&fileName={checksum.FileName}");
        String data = await res.Result.Content.ReadAsStringAsync();
        return _api.Deserialize<bool>(data);
    }
