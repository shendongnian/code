    using Newtonsoft.Json;
    using System.Linq;
    // -----------
    var data = "\"Product\",\"Date\",\"Expiry\",\"Type\",\"Price\":\"ABC\",\"20-Jul-2019\",\"20-Jul-2022\",\"Supplement\",\"1300\":\"XYZ\",\"20-Jul-2019\",\"20-Jul-2022\",\"Supplement\",\"100\":\"AAA\",\"20-Jul-2019\",\"20-Jul-2022\",\"Supplement\",\"200\":\"XXX\",\"20-Jul-2019\",\"20-Jul-2022\",\"Supplement\",\"500\"";
    var datas = data.Split(':'); // string[] containing each line of the CSV
    var MemberNames = datas[0].Split(','); // the first line, that contains the member names
    var MYObj = datas.Skip(1) // don't take the first line (member names)
                     .Select((x) => x.Split(',') // split each lines
                                     /*
                                      * create an anonymous collection
                                      * with object having 2 properties Key and Value
                                      * (and removes the unneeded ")
                                      */
                                     .Select((y, i) => new { Key = MemberNames[i].Trim('"'),
                                                             Value = y.Trim('"') })
                                     // convert it to a Dictionary
                                     .ToDictionary(d => d.Key, d => d.Value));
    // MYObject is IEnumerable<Dictionary<string, string>>
    // serialize (remove indented if needed)
    var Json = JsonConvert.SerializeObject(MYObj, Formatting.Indented);
    Debug.WriteLine(Json);
