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
**Note2:** As mentioned in a comment below, using the above approach (HeroCard) could end up with a truncated title if the text is too long. To avoid this you could use [Adaptive Dialogs](https://github.com/Microsoft/BotBuilder-Samples/tree/master/experimental/adaptive-dialog#readme) or [Adaptive Cards](https://github.com/microsoft/BotBuilder-Samples/blob/master/samples/csharp_dotnetcore/07.using-adaptive-cards/Bots/AdaptiveCardsBot.cs).
**EDIT**
Based on [this sample](https://github.com/microsoft/BotBuilder-Samples/tree/master/experimental/qnamaker-prompting/csharp_dotnetcore)
You should be able to achieve a single level of prompts with something like this:
QnAResult.cs
	public class QnAResult
	{
		public string[] Questions { get; set; }
		public string Answer { get; set; }
		public double Score { get; set; }
		public int Id { get; set; }
		public string Source { get; set; }
		public QnAMetadata[] Metadata { get; set; }
		public QnAContext Context { get; set; }
	}
QnAResultList.cs
public class QnAResultList
	{
		public QnAResult[] Answers { get; set; }
	}
IQnAService.cs
	public interface IQnAService
	{
		Task<QnAResult[]> QueryQnAServiceAsync(string query, QnABotState qnAcontext, QnAMakerEndpoint qnAMakerEndpoint);
	}
QnAService.cs
public class QnAService : IQnAService
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;
		public QnAService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}
		public async Task<QnAResult[]> QueryQnAServiceAsync(string query, QnABotState qnAcontext, QnAMakerEndpoint qnAMakerEndpoint)
		{
			var options = new QnAMakerOptions
			{
				Top = 3
			};
			var hostname = qnAMakerEndpoint.Host;
			var endpoint = new QnAMakerEndpoint
			{
				KnowledgeBaseId = qnAMakerEndpoint.KnowledgeBaseId,
				EndpointKey = qnAMakerEndpoint.EndpointKey,
				Host = hostname
			};
			var requestUrl = $"{endpoint.Host}/knowledgebases/{endpoint.KnowledgeBaseId}/generateanswer";
			var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
			var jsonRequest = JsonConvert.SerializeObject(
				new
				{
					question = query,
					top = options.Top,
					context = qnAcontext,
					strictFilters = options.StrictFilters,
					metadataBoost = options.MetadataBoost,
					scoreThreshold = options.ScoreThreshold,
				}, Formatting.None);
			request.Headers.Add("Authorization", $"EndpointKey {endpoint.EndpointKey}");
			request.Content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
			var response = await _httpClient.SendAsync(request);
			response.EnsureSuccessStatusCode();
			var contentString = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<QnAResultList>(contentString);
			return result.Answers;
		}
	}
CardHelper.cs
    public class CardHelper
	{
		/// <summary>
		/// Get Hero card
		/// </summary>
		/// <param name="cardTitle">Title of the card</param>
		/// <param name="prompts">List of suggested prompts</param>
		/// <returns>Message activity</returns>
		public static Activity GetHeroCardWithPrompts(string cardTitle, QnAPrompts[] prompts)
		{
			var chatActivity = Activity.CreateMessageActivity();
			var buttons = new List<CardAction>();
			var sortedPrompts = prompts.OrderBy(r => r.DisplayOrder);
			foreach (var prompt in sortedPrompts)
			{
				buttons.Add(
					new CardAction()
					{
						Value = prompt.DisplayText,
						Type = ActionTypes.ImBack,
						Title = prompt.DisplayText
					});
			}
			var plCard = new HeroCard()
			{
				Title = cardTitle,
				Subtitle = string.Empty,
				Buttons = buttons
			};
			var attachment = plCard.ToAttachment();
			chatActivity.Attachments.Add(attachment);
			return (Activity)chatActivity;
		}
    }
MyBot.cs HandleQnA()
QnAResult[] qnaResults =  await _qnAService.QueryQnAServiceAsync(context.Activity.Text, new QnABotState(), _qnAMakerEndpoint);
				if (qnaResults.Any())
				{
					// Get result by highest confidence
					QnAResult highestRankedResult = qnaResults.OrderByDescending(x => x.Score).First();
					string answer = highestRankedResult.Answer;
					QnAPrompts[] prompts = highestRankedResult.Context?.Prompts;
					if (prompts == null || prompts.Length < 1)
					{
						await context.SendActivityAsync(answer, cancellationToken: cancellationToken);
					}
					else
					{
						await context.SendActivityAsync(CardHelper.GetHeroCardWithPrompts(answer, prompts), cancellationToken: cancellationToken);
					}
				}
The NuGet packages I am using are:
[![packages][1]][1]
  [1]: https://i.stack.imgur.com/rd16x.png
