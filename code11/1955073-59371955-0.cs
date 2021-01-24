// Main JObject
var mainObj = new JObject();
// Syntax i love
var obj1 = new JObject
{
    {"name", "CorrM"},
    {"ip", "127.0.0.1"}
};
// Syntax are accepted too
var obj2 = new JObject();
obj2.Add("bla1", "bla");
obj2.Add("bla2", "bla");
// Combine on one JObject
mainObj.Add("FieldName1", obj1);
mainObj.Add("FieldName2", obj2);
Then add to body (Convert to string).
(i don't know that the correct way to set the Body or not)
restRequest.AddParameter("application/json", mainObj.ToString(Formatting.None), ParameterType.RequestBody);
Output string must looks like that
json
{
  "FieldName1": {
    "name": "CorrM",
    "ip": "127.0.0.1"
  },
  "FieldName2": {
    "bla1": "bla",
    "bla2": "bla"
  }
}
