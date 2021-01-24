    private async Task RemoveAttachmentMsgsAsync(SocketMessage msg)
    {
        // check if the source channel is a message channel in a guild
        if (msg.Channel is SocketTextChannel textChannel)
        {
            // get the current user to check for permissions
            var currentUser = textChannel.Guild.CurrentUser;
            // bail if the bot does not have manage message permission
            if (!currentUser.GetPermissions(textChannel).ManageMessages) return;
        }
        // if we made it this far, we can assume that the bot has permission for
        // the channel (including DM channel)
        // use LINQ Any to check if the attachment contains anything
        if (msg.Attachments.Any())
            await msg.DeleteAsync();
    }
