Stream responded;
HttpResponseMessage response = await client.GetAsync(new Uri(path));
if (response.IsSuccessStatusCode)
{
        response.Content.ReadAsStringAsync().Wait();
        responded = response.Content.ReadAsStreamAsync().Result;
        Stream decompressed = new GZipStream(responded, CompressionMode.Decompress);
        StreamReader objReader = new StreamReader(decompressed, Encoding.UTF8);
        string sLine;
        sLine = objReader.ReadToEnd();
}
and it works properly. 
