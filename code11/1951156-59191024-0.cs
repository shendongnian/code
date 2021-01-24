using Newtonsoft.Json;
public static string WrapAndSerialize(object value){
    return JsonConvert.SerializeObject(new { Data = JsonConvert.SerializeObject(value) });	
}
Using it like:
var myObject= 
  new
  {
     Name = "HelloWorld",
     BirthDate = "2020-03-03", 
     BirthPlace = "Nowhere",
  };
var Data= WrapAndSerialize(myObject);
using (var client = new HttpClient())
{
    HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, Data);
}
[LiveDemo](https://dotnetfiddle.net/4UNg04)
