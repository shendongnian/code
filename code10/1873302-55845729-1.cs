    public static IMessageActivity ForChannel(string channelId, IList<Choice> list, string text = null, string speak = null, ChoiceFactoryOptions options = null)
    {
        channelId = channelId ?? string.Empty;
        list = list ?? new List<Choice>();
        // Find maximum title length
        var maxTitleLength = 0;
        foreach (var choice in list)
        {
            var l = choice.Action != null && !string.IsNullOrEmpty(choice.Action.Title) ? choice.Action.Title.Length : choice.Value.Length;
            if (l > maxTitleLength)
            {
                maxTitleLength = l;
            }
        }
        // Determine list style
        var supportsSuggestedActions = Channel.SupportsSuggestedActions(channelId, list.Count);
        var supportsCardActions = Channel.SupportsCardActions(channelId, list.Count);
        var maxActionTitleLength = Channel.MaxActionTitleLength(channelId);
        var hasMessageFeed = Channel.HasMessageFeed(channelId);
        var longTitles = maxTitleLength > maxActionTitleLength;
        if (!longTitles && !supportsSuggestedActions && supportsCardActions)
        {
            // SuggestedActions is the preferred approach, but for channels that don't
            // support them (e.g. Teams, Cortana) we should use a HeroCard with CardActions
            return HeroCard(list, text, speak);
        }
        else if (!longTitles && supportsSuggestedActions)
        {
            // We always prefer showing choices using suggested actions. If the titles are too long, however,
            // we'll have to show them as a text list.
            return SuggestedAction(list, text, speak);
        }
        else if (!longTitles && list.Count <= 3)
        {
            // If the titles are short and there are 3 or less choices we'll use an inline list.
            return Inline(list, text, speak, options);
        }
        else
        {
            // Show a numbered list.
            return List(list, text, speak, options);
        }
    }
