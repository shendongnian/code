    using System.Web.Script.Serialization;
    //using Newtonsoft.Json
    [HttpGet]
    public void nextPage(string json)
    {
      try
      {
        var serializer = new JavaScriptSerializer();
        dynamic jsondata = serializer.Deserialize(json, typeof(object));
        //Deserialize your JSON string if the struccture is an array
        //var deserializedjson=JsonConvert.DeserializeObject<List<RisposteUtente>>(json);
        //Get your variables here from AJAX call if the string is not an array
        var idDomanda = jsondata["idDomanda"];
        var valore =jsondata["valore"];
        //Do something with your variables here 
        Console.WriteLine("");
    
      }
      catch (Exception e)
      {
        Console.Write("");
      }
    }
