csharp
var activity = turnContext.Activity;
if (string.IsNullOrWhiteSpace(activity.Text) && !string.IsNullOrWhiteSpace(activity.Value))
{
	activity.Text = JsonConvert.SerializeObject(activity.Value);
}
