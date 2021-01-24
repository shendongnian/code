 class Rootobject
 {
   Public Event[] Events{get;set;}
 }
 class Event
 {
   Public string Name{get;set;}
   Public Parameter[] Parameters{get;set;}
 }
 class Parameter
 {
   Public string Property{get;set;}
   Public string Value{get;set;}
 }
You can use `JSON.NET` to deserialize your JSON into the strongly-typed class.
var obj = JsonConvert.Deserialize<Rootobject>(inputStr);
**Update 1:**
If you wish to read data fully dynamically without creating POCO classes, you can deserialize the input `JSON` into a `JObject`:
Newtonsoft.JSON.Linq.JObject obj = JsonConvert.Deserilaze(inputStr) as Newtonsoft.JSON.Linq.JObject;
if(obj != null)
{
    var firstValue =   obj["Events"][0]["Parameters"][0].Value;
}
  [1]: https://www.nuget.org/packages/Newtonsoft.Json/12.0.2
