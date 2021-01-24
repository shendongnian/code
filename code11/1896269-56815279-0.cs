    using System;
    using Discord;
    using System.Threading.Tasks;
    using Discord.WebSocket;
    
    namespace Bot
    {
        class Program
        {
            private DiscordSocketClient Client;
    
            static void Main() => new Program().MainAsync().GetAwaiter().GetResult();
    
            public async Task MainAsync()
            {
                try{
                Client = new DiscordSocketClient();
                Client.Log += Log;
                }catch(Exception ex){log("Error in init:"); throw ex;}
                //This is my discord bot token
                var token = "XXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                try{
                await Client.LoginAsync(TokenType.Bot, token);
                }catch(Exception ex){log("Error during login"); throw ex;}
                try{
                await Client.StartAsync();
                }catch(ex){log("Error starting client"); throw ex;
                await Task.Delay(-1);
            }
            private Task log(string message)
            {
                Console.WriteLine(message);
                return Task.CompletedTask;
            }            
            private Task Log(LogMessage message)
            {
                Console.WriteLine(message.ToString());
                return Task.CompletedTask;
            }
        }
    }
