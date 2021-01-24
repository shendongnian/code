    /// <summary>
    /// Determine if a number of Suggested Actions are supported by a Channel.
    /// </summary>
    /// <param name="channelId">The Channel to check the if Suggested Actions are supported in.</param>
    /// <param name="buttonCnt">(Optional) The number of Suggested Actions to check for the Channel.</param>
    /// <returns>True if the Channel supports the buttonCnt total Suggested Actions, False if the Channel does not support that number of Suggested Actions.</returns>
    public static bool SupportsSuggestedActions(string channelId, int buttonCnt = 100)
    {
        switch (channelId)
        {
            // https://developers.facebook.com/docs/messenger-platform/send-messages/quick-replies
            case Connector.Channels.Facebook:
            case Connector.Channels.Skype:
                return buttonCnt <= 10;
            // ...
        }
    }
