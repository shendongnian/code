c#
List<string> tmp = new List<string>();
using (var sr = new StreamReader("C:\\Temp\\tst.txt")) // tst.txt contains the url-response
{
    while(!sr.EndOfStream)
        tmp.Add(sr.ReadLine());
}
WallMartData[] x = JsonConvert.DeserializeObject<WallMartData[]>(string.Join("\n", tmp));
In your case it would be:
c#
string url = "http://api.walmartlabs.com/v1/items?apiKey=3zmwbajjf4ugzqhdtgsf59ac&upc=029986182548";
             var client = new RestClient(url);
             var request = new RestRequest(Method.GET);
             IRestResponse response = client.Execute(request);
             var deserializer = new JsonDeserializer();
             var wmr = deserializer.Deserialize<WallMartData[]>(response); // See the bracer here ;-)
