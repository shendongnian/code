csharp
private async void ContinuousRecognitionSession_Completed(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionCompletedEventArgs args)
{
    await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        textBlock1.Text = "Timeout.";
    });
    sender.ResultGenerated -= ContinuousRecognitionSession_ResultGenerated;
    sender.ResultGenerated += ContinuousRecognitionSession_ResultGenerated;
    await sender.StartAsync();
}
Incidentally, there is no direct evidence that rebinding events can ensure that they work properly. But it does improve the success rate of event triggering
Best regards.
