    using System.Dynamic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    // ... other code removed
    // You already have a means that loads your pseudo-json into results
    // I used a file for the sake of this example
    string results = File.ReadAllText(@"C:\temp\sample.json");
    var o = JObject.Parse(results);
    var headers = o.SelectToken("cols")
        .Select(x => { return new { label = x.SelectToken("label").Value<string>(), type = x.SelectToken("type").Value<string>()}; }).ToArray();
    var rows = o.SelectToken("rows").Select(s => { return s.SelectToken("c");}).ToList();
    Func<JConstructor, DateTime> MapAsDateTime = (s) =>
    {
        // This is sloppy on my part, you should improve this as you like.
        List<int> v = new List<int>();
        foreach (JToken t in s)
        {
            v.Add(t.Value<int>());
        }
        return new DateTime(v[0], v[1], v[2], v[3], v[4], v[5]);
    };
    IEnumerable<dynamic> finalValues = rows.Select(s =>
        {
            var innerValues = s.ToList().Select(x => { return x.SelectToken("v"); }).ToArray();
            int i = 0;
            dynamic val = new ExpandoObject();
            IDictionary<string, object> valueMap = (IDictionary<string, object>)val;
            foreach (var innerValue in innerValues)
            {
                switch (headers[i].type)
                {
                    case "string":
                        // NOTE: This can be improved, you could try to match and convert GUIDs with a regex or something else.
                        valueMap[headers[i].label] = innerValue.Value<string>();
                        break;
                    case "datetime":
                        valueMap[headers[i].label] = MapAsDateTime((JConstructor)innerValue);
                        break;
                    case "number":
                        // NOTE: This can be improved, your specific case needs decimal to handle things like 0.25, but many others could get by with just int
                        valueMap[headers[i].label] = innerValue.Value<decimal>();
                        break;
                    case "boolean":
                        valueMap[headers[i].label] = innerValue.Value<bool>();
                        break;
                    default:
                        // NOTE: You will need to add more cases if they 'define' more types.
                        throw new ArgumentException(string.Format("unhandled type \"{0}\" found in schema headers.", headers[i].type));
                }
                i++;
            }
            return val;
        });
    foreach (dynamic d in finalValues)
    {
        Console.WriteLine("name: {0}", d.name);
        Console.WriteLine("caller_id_number: {0}", d.caller_id_number);
        Console.WriteLine("destination_number: {0}", d.destination_number);
        Console.WriteLine("call_start: {0}", d.call_start);
        Console.WriteLine("duration: {0}", d.duration);
        Console.WriteLine("bill_seconds: {0}", d.bill_seconds);
        Console.WriteLine("uuid: {0}", d.uuid);
        Console.WriteLine("call_bill_total: {0}", d.call_bill_total);
        Console.WriteLine("recorded: {0}", d.recorded);
        Console.WriteLine("--");
    }
