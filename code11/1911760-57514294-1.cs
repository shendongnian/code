    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Telegram.Bot;
    using Xunit;
    namespace StackOverflowSupport
    {
        public class Tests
        {
            [Fact]
            public async Task SendFileWithTelegramBot()
            {
                // Requires NuGet package `Telegram.Bot` (v15.0.0)
                var token = "YOUR_TOKEN";
                using (var http = new HttpClient())
                {
                    int chatId = 42;
                    var imageFile = File.Open("filepath", FileMode.Open);
                    var bot = new TelegramBotClient(token, http);
                    await bot.SendPhotoAsync(chatId, photo: imageFile, caption: "This is a Caption");
                }
            }
        }
    }
