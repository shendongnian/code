    [HttpPost]
    public JsonResult SampleMethod()
    {
        dynamic prmModel= System.Web.Helpers.Json.Decode((new StreamReader(Request.InputStream).ReadToEnd()));
    
        Newtonsoft.Json.Schema.JsonSchema schema = JsonSchema.Parse(Jsonschema());
        Newtonsoft.Json.Linq.JObject user = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(input));
        if (!user.IsValid(schema) || user.Count > 2)
            return Json("Bad Request");
    }
    public string Jsonschema()
    {
        string schemaJson = @"{
            'description': 'A',
            'type': 'object',
            'properties': {
                'UserName':{'type':'string'},
                'Password':{'type':'string'}
                }
            }";
    
        return schemaJson;
    }
