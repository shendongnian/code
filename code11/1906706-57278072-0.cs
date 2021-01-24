var serializer = new JsonSerializer();
using(var reader = new StreamReader(request.GetResponse().GetResposeStream()))
using (var jsonTextReader = new JsonTextReader(reader))
{
        var obj = serializer.Deserialize<Organization>(jsonTextReader);
}
