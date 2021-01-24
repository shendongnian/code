stepContext.Context.Activity.Text = "The phrase that you want to pass through here";
Do this assignment _BEFORE_ you call `LuisHelper.ExecuteLuisQuery` otherwise your updated `Text` value won't be sent through.
---
**Why this should work**
Since `LuisHelper.ExecuteLuisQuery(Configuration, Logger, stepContext.Context, cancellationToken)` passes through `stepContext.Context` and under the scenes [here](https://github.com/microsoft/BotBuilder-Samples/blob/master/samples/csharp_dotnetcore/13.core-bot/LuisHelper.cs#L33) this context is passed into the `RecognizeAsync` call inside of the `ExecuteLuisQuery` method. Furthermore the `recognizer` variable is of type `LuisRecognizer`, the source code for this class is available [here](https://github.com/microsoft/botbuilder-dotnet/blob/2e0f146cf6da18f5b828f820fb218742e98a9dcf/libraries/Microsoft.Bot.Builder.AI.LUIS/LuisRecognizer.cs). The line that you are interested in is [this one](https://github.com/microsoft/botbuilder-dotnet/blob/2e0f146cf6da18f5b828f820fb218742e98a9dcf/libraries/Microsoft.Bot.Builder.AI.LUIS/LuisRecognizer.cs#L334) which shows the `Text` property of the `turnContext` being used as the utterance which is passed through.
---
**Source code explanation/Extra info**
For future reference (incase the code or links change) a simplified version of the source code is:
public virtual async Task<RecognizerResult> RecognizeAsync(ITurnContext turnContext, CancellationToken cancellationToken)
            => await RecognizeInternalAsync(turnContext, null, null, null, cancellationToken).ConfigureAwait(false);
where `RecognizeInteralAsync` looks like:
private async Task<RecognizerResult> RecognizeInternalAsync(ITurnContext turnContext, LuisPredictionOptions predictionOptions, Dictionary<string, string> telemetryProperties, Dictionary<string, double> telemetryMetrics, CancellationToken cancellationToken)
{
    var luisPredictionOptions = predictionOptions == null ? _options : MergeDefaultOptionsWithProvidedOptions(_options, predictionOptions);
    BotAssert.ContextNotNull(turnContext);
    if (turnContext.Activity.Type != ActivityTypes.Message)
    {
        return null;
    }
    // !! THIS IS THE IMPORTANT LINE !!
    var utterance = turnContext.Activity?.AsMessageActivity()?.Text;
    RecognizerResult recognizerResult;
    LuisResult luisResult = null;
    if (string.IsNullOrWhiteSpace(utterance))
    {
        recognizerResult = new RecognizerResult
        {
            Text = utterance,
            Intents = new Dictionary<string, IntentScore>() { { string.Empty, new IntentScore() { Score = 1.0 } } },
            Entities = new JObject(),
        };
    }
    else
    {
        luisResult = await _runtime.Prediction.ResolveAsync(
            _application.ApplicationId,
            utterance,
            timezoneOffset: luisPredictionOptions.TimezoneOffset,
            verbose: luisPredictionOptions.IncludeAllIntents,
            staging: luisPredictionOptions.Staging,
            spellCheck: luisPredictionOptions.SpellCheck,
            bingSpellCheckSubscriptionKey: luisPredictionOptions.BingSpellCheckSubscriptionKey,
            log: luisPredictionOptions.Log ?? true,
            cancellationToken: cancellationToken).ConfigureAwait(false);
        recognizerResult = new RecognizerResult
        {
            Text = utterance,
            AlteredText = luisResult.AlteredQuery,
            Intents = LuisUtil.GetIntents(luisResult),
            Entities = LuisUtil.ExtractEntitiesAndMetadata(luisResult.Entities, luisResult.CompositeEntities, luisPredictionOptions.IncludeInstanceData ?? true),
        };
        LuisUtil.AddProperties(luisResult, recognizerResult);
        if (_includeApiResults)
        {
            recognizerResult.Properties.Add("luisResult", luisResult);
        }
    }
    // Log telemetry code
    await OnRecognizerResultAsync(recognizerResult, turnContext, telemetryProperties, telemetryMetrics, cancellationToken).ConfigureAwait(false);
    var traceInfo = JObject.FromObject(
        new
        {
            recognizerResult,
            luisModel = new
            {
                ModelID = _application.ApplicationId,
            },
            luisOptions = luisPredictionOptions,
            luisResult,
        });
    await turnContext.TraceActivityAsync("LuisRecognizer", traceInfo, LuisTraceType, LuisTraceLabel, cancellationToken).ConfigureAwait(false);
    return recognizerResult;
}
