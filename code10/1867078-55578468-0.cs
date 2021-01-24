private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
{
    var activity = await result as Activity;
    if (activity.Value != null)
    {
        dynamic value = activity.Value;
        var category = value.Category;
        await context.PostAsync(category);
    }
    context.Wait(MessageReceivedAsync);
}
Using dynamics it's very easy to access the values. Simply register this message as callback function on `context.Wait` in your initial prompt where you send your adaptive card. 
If you would like to have a more typed version, you could model the result of you card and parse it like this:
private static string GetTypedCategoryFromAdaptiveCard(Activity activity)
{
    var content = JsonConvert.DeserializeObject<CategoryResponse>(activity.Value.ToString());
    return content.Category;
}
public class CategoryResponse
{
    public string Category { get; set; }
}
