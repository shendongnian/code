    public class MyController : ApiController
    {
        // POST is not really the right choice for operations that only GET something
        // but if you want to pass an object as parameter you really don't have much of a choice
        [HttpPost]
        public HttpResponseMessage DoSomeAction(ActionDetails details)
        {
            // prepare the result content
            string jsonResult = "{}";
            switch (details.action) 
            {
                case "getExternalServicePar":
                    var action1Result = GetFromSomewhere(details.args.id); // do something
                    jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(action1Result);
                    break;
                case "incrementVallet":
                    var action2Result = ...; // do something else
                    jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(action2Result);
                    break;
            }
            // put the serialized object into the response (and hope the client knows what to do with it)
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonResult, Encoding.UTF8, "application/json");
            return response;
        }
    }
    
