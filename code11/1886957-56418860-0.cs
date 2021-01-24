public async Task<QnAResult[]> QueryQnAServiceAsync(string query, QnABotState qnAcontext)
{
    var requestUrl = $"{_endpoint.Host}/knowledgebases/{_endpoint.KnowledgeBaseId}/generateanswer";
    var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
    var jsonRequest = JsonConvert.SerializeObject(
        new
        {
            question = query,
            top = _options.Top,
            context = qnAcontext,
            strictFilters = _options.StrictFilters,
            metadataBoost = _options.MetadataBoost,
            scoreThreshold = _options.ScoreThreshold,
        }, Formatting.None);
    request.Headers.Add("Authorization", $"EndpointKey {_endpoint.EndpointKey}");
    request.Content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
    var response = await _httpClient.SendAsync(request);
    response.EnsureSuccessStatusCode();
    var contentString = await response.Content.ReadAsStringAsync();
    var result = JsonConvert.DeserializeObject<QnAResultList>(contentString);
    return result.Answers;
}
Then inspect the result for any prompts, and act accordingly:
var query = inputActivity.Text;           
var qnaResult = await _qnaService.QueryQnAServiceAsync(query, new QnABotState());
var qnaAnswer = qnaResult[0].Answer;
var prompts = qnaResult[0].Context?.Prompts;
if (prompts == null || prompts.Length < 1)
{
    outputActivity = MessageFactory.Text(qnaAnswer);
}
else
{
    outputActivity = CardHelper.GetHeroCard(qnaAnswer, prompts);
}
await turnContext.SendActivityAsync(outputActivity);
**Note:** The code above for "acting accordingly" will only work for a single level of prompts, as per my answer that I linked at the top. If you want to support multiple levels of prompts then you will have to implement as state system as per [this sample](https://github.com/microsoft/BotBuilder-Samples/tree/master/experimental/qnamaker-prompting/csharp_dotnetcore) - see my other answer [here](https://stackoverflow.com/a/56367963/5209435) for more details.
