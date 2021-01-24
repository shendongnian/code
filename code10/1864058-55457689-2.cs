    public class TextToSpeechMiddleware : IMiddleware
    {
    	private readonly IEnumerable<string> ignoreList;
    
    	public TextToSpeechMiddleware(string speakIgnore)
    	{
    		ignoreList = GetSpeakIgnore(speakIgnore);
    	}
    
    	public Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
    	{
    		turnContext.OnSendActivities(OnSendActivities);
    		turnContext.OnUpdateActivity(OnUpdateActivity);
    
    		return next(cancellationToken);
    	}
    
    	private static IEnumerable<string> GetSpeakIgnore(string value)
    	{
    		string[] ignoreList = value.Split(';');
    
    		return ignoreList.Select(i => i.Trim())
    						 .Where(i => !string.IsNullOrEmpty(i));
    	}
    
    	private Task<ResourceResponse> OnUpdateActivity(ITurnContext turnContext, Activity activity, Func<Task<ResourceResponse>> next)
    	{
    		ConvertTextToSpeech(activity);
    		return next();
    	}
    
    	private Task<ResourceResponse[]> OnSendActivities(ITurnContext turnContext, List<Activity> activities, Func<Task<ResourceResponse[]>> next)
    	{
    		foreach (Activity currentActivity in activities.Where(a => a.Type == ActivityTypes.Message))
    		{
    			ConvertTextToSpeech(currentActivity);
    		}
    
    		return next();
    	}
    
    	private void ConvertTextToSpeech(Activity message)
    	{
    		Activity initialMessage = message;
    
    		try
    		{
    			if (message.Type == ActivityTypes.Message)
    			{
    				bool ignoredSpeak = false;
    				if (string.IsNullOrEmpty(message.Speak))
    				{
    					if (string.IsNullOrEmpty(message.Text))
    					{
    						if (message.Attachments[0].Content is HeroCard attachment)
    						{
    							message.Speak = TextToSpeechHelper.ConvertTextToSpeechText(attachment.Text);
    						}
    					}
    					else
    					{
    						message.Speak = TextToSpeechHelper.ConvertTextToSpeechText(message.Text);
    					}
    
    					message.Speak = message.Speak.Trim();
    
    					if (ignoreList.Where(i => message.Speak.ToLower().StartsWith(i.ToLower())).Count() != 0)
    					{
    						message.Speak = null;
    						ignoredSpeak = true;
    					}
    				}
    				else if (string.IsNullOrWhiteSpace(message.Speak))
    				{
    					message.Speak = " ";
    				}
    
    				if ((!string.IsNullOrEmpty(message.Speak) && (message.Speak.EndsWith("?") || message.Speak.StartsWith("Is this correct?")))
    					 || (!string.IsNullOrEmpty(message.Text) && message.Text.EndsWith("?"))
    					 || ignoredSpeak)
    				{
    					message.InputHint = InputHints.ExpectingInput;
    				}
    
    				// IOs won't work with expecting input
    				if (message.Recipient.Name.EndsWith(":ios"))
    				{
    					message.InputHint = InputHints.AcceptingInput;
    				}
    			}
    
    			// Logic needed to increase speech speed.
    			// if (!string.IsNullOrEmpty(message.Speak))
    			// {
    			//    message.Speak = @"<speak version='1.0' " + "xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-GB'><prosody rate=\"1.5\">" + message.Speak + "</prosody></speak>";
    			// }
    		}
    		catch (Exception)
    		{
    			message = initialMessage;
    		}
    	}
    }
