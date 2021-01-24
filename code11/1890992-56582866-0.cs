cs
await user.ModifyAsync(x =>
{
    var voiceChannel = Program.client.GetChannel(588025239103995904) as IVoiceChannel;
    x.Channel = Optional.Create(voiceChannel);
});
