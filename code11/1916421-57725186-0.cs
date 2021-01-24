    var oldChannel = ((ITextChannel)channel);
    
    // Assuming you have a variable 'guild' that is a IGuild
    // (Which is your targeted guild)
    await guild.CreateTextChannelAsync(oldChannel.Name, newChannel =>
    {
        // Copies over all the properties of the channel to the new channel
        newChannel.CategoryId = oldChannel.CategoryId;
        newChannel.Topic = oldChannel.Topic;
        newChannel.Position = oldChannel.Position;
        newChannel.SlowModeInterval = oldChannel.SlowModeInterval;
        newChannel.IsNsfw = oldChannel.IsNsfw;
    });
    
    await oldChannel.DeleteAsync();
