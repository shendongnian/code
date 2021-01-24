using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
Dictionary<string, string> dic = new Dictionary<string, string>();
string js = @"{ ""One"": ""Hey"", ""Two"": { ""Two"": ""HeyHey"" }, ""Three"": { ""Three"": { ""Three"": ""HeyHeyHey"" } } }";
dynamic d = JObject.Parse(js);
CreateDictionary(d, "");
private void CreateDictionary(dynamic d, string key)
{
    PropertyDescriptorCollection properties = (d as ICustomTypeDescriptor).GetProperties();
    foreach (PropertyDescriptor pd in properties)
    {
        if (d[pd.Name].Value == null)
            CreateDictionary(d[pd.Name], key + pd.Name + ":");
        else
            dic.Add(key + pd.Name, d[pd.Name].Value.ToString());
    }
}
