private bool voiceCheck;
        public AudioService() { voiceCheck = false; }
public async Task<IAudioClient> ConnecttoVC(SocketCommandContext ctx)
        {
            SocketGuildUser user = ctx.User as SocketGuildUser;
            IVoiceChannel chnl = user.VoiceChannel;
            if(chnl == null)
            {
                await ctx.Channel.SendMessageAsync("Not connected!");
                return null;
            }
            if(voiceCheck == true)
            {
                await ctx.Channel.SendMessageAsync("Already connected!");
                return null;
            }
            await ctx.Channel.SendMessageAsync("Joining Voice!");
            voiceCheck = true;
            return await chnl.ConnectAsync();
        }
Between my `ConnecttoVC` and `Leave`(omitted) methods, voiceCheck would switch between true and false while checking for each respectively.
