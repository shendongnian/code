    // Create a single, static SftpClient
    private static SftpClient client = new sftpClient(endpoint, user, pass);
    
    public static async Task Run(string input)
    {
        var response = await sftpClient.SendAsync("filename.txt", input);
    }
