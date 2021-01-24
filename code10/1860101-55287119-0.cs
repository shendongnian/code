class Example {
  public int property_to_map {get; set;}
}
class ApiCalls{
  public void MakeApiCall() {
     var response = ApiCall();
     var MappedObject = JsonConvert.Deserialize<Example>(response);
     //Do whatever you need now with the mapped object.
  }
}
  [1]: https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonConvert_DeserializeObject__1.htm
