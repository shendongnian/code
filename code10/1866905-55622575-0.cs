cs
Console.WriteLine("Enter the text to recognize:");
string input = Console.ReadLine().Trim();
if (input.ToLower() == "exit")
{
    // Close application if user types "exit"
    break;
}
else
{
    if (input.Length > 0)
    {
        // Create client with SuscriptionKey and AzureRegion
        var client = new LuisRuntimeAPI(new ApiKeyServiceClientCredentials(SubscriptionKey))
        {
            AzureRegion = AzureRegion
        };
        // Predict
        var result = await client.Prediction.ResolveAsync(ApplicationId, input);
        // Print result
        var json = JsonConvert.SerializeObject(result, Formatting.Indented);
        Console.WriteLine(json);
        Console.WriteLine();
    }
}
  [1]: https://github.com/Azure-Samples/Cognitive-Services-LUIS-Console-Application/blob/master/Microsoft.Azure.CognitiveServices.LUIS.Sample/Program.cs
