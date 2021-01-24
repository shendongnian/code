using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
2. Add following classes to match the JSON response shape:
class FollowUpCheckResult
 {
     [JsonProperty("answers")]
     public FollowUpCheckQnAAnswer[] Answers
     {
         get;
         set;
     }
 }
 class FollowUpCheckQnAAnswer
 {
     [JsonProperty("context")]
     public FollowUpCheckContext Context
     {
         get;
         set;
     }
 }
 class FollowUpCheckContext
 {
     [JsonProperty("prompts")]
     public FollowUpCheckPrompt[] Prompts
     {
         get;
         set;
     }
 }
 class FollowUpCheckPrompt
 {
     [JsonProperty("displayText")]
     public string DisplayText
     {
         get;
         set;
     }
 }
3. After the qnaMaker.GetAnswersAsync succeeds and there is valid answer, perform an additional HTTP query to check the follow-up prompts:
// The actual call to the QnA Maker service.
 var response = await qnaMaker.GetAnswersAsync(turnContext);
 if (response != null && response.Length > 0)
 {
     // create http client to perform qna query
     var followUpCheckHttpClient = new HttpClient();
     // add QnAAuthKey to Authorization header
     followUpCheckHttpClient.DefaultRequestHeaders.Add("Authorization", _configuration["QnAAuthKey"]);
     // construct the qna query url
     var url = $"{GetHostname()}/knowledgebases/{_configuration["QnAKnowledgebaseId"]}/generateAnswer"; 
     // post query
     var checkFollowUpJsonResponse = await followUpCheckHttpClient.PostAsync(url, new StringContent("{\"question\":\"" + turnContext.Activity.Text + "\"}", Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync();
     // parse result
     var followUpCheckResult = JsonConvert.DeserializeObject<FollowUpCheckResult>(checkFollowUpJsonResponse);
     // initialize reply message containing the default answer
     var reply = MessageFactory.Text(response[0].Answer);
     if (followUpCheckResult.Answers.Length > 0 && followUpCheckResult.Answers[0].Context.Prompts.Length > 0)
     {
         // if follow-up check contains valid answer and at least one prompt, add prompt text to SuggestedActions using CardAction one by one
         reply.SuggestedActions = new SuggestedActions();
         reply.SuggestedActions.Actions = new List<CardAction>();
         for (int i = 0; i < followUpCheckResult.Answers[0].Context.Prompts.Length; i++)
         {
             var promptText = followUpCheckResult.Answers[0].Context.Prompts[i].DisplayText;
             reply.SuggestedActions.Actions.Add(new CardAction() { Title = promptText, Type = ActionTypes.ImBack, Value = promptText });
         }
     }
     await turnContext.SendActivityAsync(reply, cancellationToken);
 }
 else
 {
     await turnContext.SendActivityAsync(MessageFactory.Text("No QnA Maker answers were found."), cancellationToken);
 }
4. Test it in Bot Framework Emulator, and it should now display the follow-up prompts as expected. 
Notes: 
Be sure to create ```IConfiguration _configuration``` property, pass IConfiguration configuration into your constructor, and update your appsettings.json with the appropriate QnAKnowledgebaseId and QnAAuthKey. 
If you used one of the Bot Samples as a starting point, note that ```QnAAuthKey``` in appsettings.json will probably be named ```QnAEndpointKey``` instead. 
You will also need a GetHostName() function or just replace that with the url for your bot's qna hostname. 
