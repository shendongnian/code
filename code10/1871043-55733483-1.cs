    using System.Linq;
    using Newtonsoft.Json;
    ..
    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    var str = string.Join(',', dict.Select(r => $"{r.Key}={r.Value}"));
