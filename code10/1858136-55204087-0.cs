   var myRequest = {
        key: 'Put an identifier here',  //Pack myRequest with whatever you need
        action: 'Put an action here',
        otherThing: 'Put other stuff here'
    };
    //To send it, you will need to serialize myRequest.  JSON.strigify will do the trick
    var requestData = JSON.stringify(myRequest);
    $.ajax({
        type: "POST",
        url: "Your URL goes here",
        data: { inputData: requestData }, //Change inputData to match the argument in your controller method
        success: function (response) {
            if (response.Status !== "OK") {
                alert("Exception: " + response.Status + " |  " + response.Message);
            }
            else {
                //Add code for successful thing here.
                //response will contain whatever you put in it on the server side.  
                //In this example I'm expecting Status, Message, and MyArray
                
            }
        },
        failure: function (response) {
            alert("Failure: " + response.Status + " |  " + response.Message);
        },
        error: function (response) {
            alert("Error: " + response.Status + " |  " + response.Message);
        }
    });
On the server side, you will need to be able to receive the request and send the data back.  
**C# / MVC / Controller Code**
[HttpPost]
public JsonResult YourMethodName(string inputData)//JSON should contain key, action, otherThing
{
    JsonResult RetVal = new JsonResult();  //We will use this to pass data back to the client
    try
    {
        var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(inputData);
        string RequestKey = JSONObj["key"];
        string RequestAction = JSONObj["action"];
        string RequestOtherThing = JSONObj["otherThing"];
        //Use your request information to build your array
        //You didn't specify what kind of array, but it works the same regardless.
        int[] ResponseArray = new int[10];
                //populate array here
        //Write out the response
        RetVal = Json(new
        {
            Status = "OK",
            Message = "Response Added",
            MyArray = ResponseArray
         });
        }
    }
    catch (Exception ex)
    {
        //Response if there was an error
        RetVal = Json(new
        {
            Status = "ERROR",
            Message = ex.ToString(),
            MyArray = new int[0]
        });
    }
    return RetVal;
}
You'll need these namespaces in your controller declaration:
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Mvc;
That should get you well on you way.  Hope it helps!
