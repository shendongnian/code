        public async Task DebugMessage(String a)
        {
            await Client.GetGuild(serverid).GetTextChannel(debugchannel).SendMessageAsync(a);
            
        }
        public async Task ScheduleMessage(String a)
        {
            await Client.GetGuild(serverid)GetTextChannel(schedulechannel).SendMessageAsync(a);
        }
I will try to fix this soon because i do not have time now.. But if someone wants to share a tip how to make a similar system but more "efficient".
This is just what i think is hapening...
