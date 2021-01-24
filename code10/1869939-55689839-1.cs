    Scenario Outline: Authenticating endpoint
    When I request transaction notification endpoint with headers <HeaderCondition>
    Then I get a response <ResponseCode>
    Examples:
    | ResponseCode | HeaderCondition |
    | Unauthorized | Unauthorized    |
    | Forbidden    | Forbidden       |
    | Ok           | Ok              |
    
    [When(@"I request notification endpoint with headers (.*)")]
    public void WhenIRequestNotificationEndpointWithHeaders(string headerCondition)
        {
            var baseurl = "(My end point)";
            var client = new RestClient(baseurl);
            var request = new RestRequest(Method.PUT);
    
            if (headerCondition.Equals("Forbidden"))
            {
                request.AddHeader("Ocp-Apim-Subscription-Key", "b601454182cf47eba7ahfjuejdksiwhfjmd");
                request.AddHeader("Content-Type", "application/json");
                //request.AddJsonBody("{\"Id\":\"123\"}");
                request.AddParameter("undefined", "{\"Id\":\"123\"}", ParameterType.RequestBody);
            }
            else if(headerCondition.Equals("Ok"))
            {
                request.AddHeader("Ocp-Apim-Subscription-Key", "b601454182cf47eba7ahfjuejdksiwhfjmd");
                request.AddHeader("Content-Type", "application/json");
                //request.AddJsonBody("{\"Id\":\"123\"}");
                request.AddParameter("undefined", "{\"Id\":\"123\"}", ParameterType.RequestBody);
                request.AddHeader("token-auth", "ToBeProvided");
            }
    
            response = client.Execute(request);
        }
