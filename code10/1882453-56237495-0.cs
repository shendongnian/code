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
  [1]: https://www.nuget.org/packages/Newtonsoft.Json/12.0.2
