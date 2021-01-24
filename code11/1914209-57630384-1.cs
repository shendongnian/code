     protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Running dialog with Message Activity.");
    
            string text = string.IsNullOrEmpty(turnContext.Activity.Text) ? string.Empty : turnContext.Activity.Text.ToLower();
    
            string topIntent = string.Empty;
            RecognizerResult luisRecognizerResult = null;
    
            string topDispatch = string.Empty;
            RecognizerResult dispatchRecognizerResult = null;
    
            if (!string.IsNullOrEmpty(text))
            {
                //luis
                var luisApplication = new LuisApplication(
                "a17b5589-80a4-4245-xxxxxxxxx",
                "4e17f6cf0574497c85cxxxxxxxxx",
                "https://southeastasia.api.cognitive.microsoft.com");
    
                var _luisRecognizer = new LuisRecognizer(luisApplication);
    
                luisRecognizerResult = await _luisRecognizer.RecognizeAsync(turnContext, cancellationToken);
                var topScoringIntent = luisRecognizerResult?.GetTopScoringIntent();
                topIntent = topScoringIntent.Value.intent;
    
                //dispatch
                var dispatchLuisApplication = new LuisApplication(
                   "f2833d51-b9d2-4420-b3b4-xxxxxxxxx",
                   "4e17f6cf0574497c85c260xxxxxxxx",
                   "https://southeastasia.api.cognitive.microsoft.com");
    
                var _dispatchLuisRecognizer = new LuisRecognizer(dispatchLuisApplication);
    
                dispatchRecognizerResult = await _dispatchLuisRecognizer.RecognizeAsync(turnContext, cancellationToken);
                var dispatchTopScoringIntent = dispatchRecognizerResult?.GetTopScoringIntent();
                topDispatch = dispatchTopScoringIntent.Value.intent;
    
                turnContext.TurnState.Add("topDispatch", topDispatch);
                turnContext.TurnState.Add("dispatchRecognizerResult", dispatchRecognizerResult);
                turnContext.TurnState.Add("topIntent", topIntent);
            }
    
    
            await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>("DialogState"), cancellationToken);
        }
