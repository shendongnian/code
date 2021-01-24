    var user = await InstaApi.UserProcessor.GetUserAsync("giorgos.xou");
    var userId = user.Value.Pk.ToString();
    var Highlights = await InstaApi.StoryProcessor.GetHighlightFeedsAsync(userId);
    foreach (InstaHighlightFeed Highlight in Highlights.Value.Items)
    {
        //sb2.AppendLine(Highlight.Title);
    }
