    static async System.Threading.Tasks.Task<Table[]> CallServerAsync()
    {
        var client = new HttpClient();
     
        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:31004/api/tables");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
        var result = await client.SendAsync(request);
        var tables = ProtoBuf.Serializer.Deserialize<Table[]>(await result.Content.ReadAsStreamAsync());
        return tables;
    }
