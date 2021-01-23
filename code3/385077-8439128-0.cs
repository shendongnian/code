      function sendToServer(licenseList)
      {
      var url = "controller.ashx";
      var data = {};
      data.SerializedObj = JSON.stringify(licenseList);
       $.post(url, data, function(response){
      	if(response.length > 0)
      	{
            alert(response);
      	}
       });
      }
      //controller.ashx :
      public void ProcessRequest (HttpContext context) {
      //...
      string serializedObj = context.Request.Form["SerializedObj"] ?? "";
      JavaScriptSerializer js = new JavaScriptSerializer();
      List<license> collection = js.Deserialize<List<license>>(serializedObj);
      
      //...
      public class license
      {
      public  string Propertie1 {get;set;}
      public  string Propertie2 {get;set;}
      }
