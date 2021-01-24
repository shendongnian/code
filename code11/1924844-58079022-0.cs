    public class Function
    {
        public SkillResponse FunctionHandler(SkillRequest req, ILambdaContext context)
        {
            // create the speech response
            var speech = new SsmlOutputSpeech();
            speech.Ssml = "<speak>This is an test.</speak>";
            // create the response
            var responseBody = new ResponseBody();
            responseBody.OutputSpeech = speech;
            responseBody.ShouldEndSession = true; // this triggers the reprompt
            responseBody.Card = new SimpleCard { Title = "Test", Content = "Testing Alexa" };
            var skillResponse = new SkillResponse();
            skillResponse.Response = responseBody;
            skillResponse.Version = "1.0";
            return skillResponse;
        }
    }
