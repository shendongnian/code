c#
public static async Task<HttpResponseMessage> Upload(string path, string name, FileStream file) {
    var method = new HttpMethod(@"PUT");
    var message = new HttpRequestMessage(method, path/name) {
        Content = new StreamContent(file)
    };
    return await HttpClient.SendAsync(message);
}
And it works... But I'm wonder how the two methods of uploading differ.
