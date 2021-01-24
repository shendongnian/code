    public class Version
    {
        public int major { get; set; }
        public int minor { get; set; }
        public int build { get; set; }
        public int revision { get; set; }
        public int majorRevision { get; set; }
        public int minorRevision { get; set; }
    }
    public class RootObject
    {
        public int id { get; set; }
        public Version version { get; set; }
        public string release_type { get; set; }
        public string release_date { get; set; }
    }
    public class Response
    {
        public RootObject request { get; set; }
        public string guid { get; set; }
        public string type { get; set; }
    }
and use these classes like this in the main,
    var model = JsonConvert.DeserializeObject<RootObject>(json);
    var httpResp = new Response();
    httpResp.guid = "p_guid";
    httpResp.type = "p_type";
    httpResp.request = model;
    Console.WriteLine(JsonConvert.SerializeObject(httpResp, Formatting.Indented));
**Output**
Above produces the following json:
{
  "request": {
    "id": 558725,
    "version": {
      "major": 3,
      "minor": 1,
      "build": 5,
      "revision": -1,
      "majorRevision": -1,
      "minorRevision": -1
    },
    "release_type": "Maintenance Release",
    "release_date": "2020-01-22"
  },
  "guid": "p_guid",
  "type": "p_type"
}
