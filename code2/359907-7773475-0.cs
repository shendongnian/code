    using System.Net;
    using System.Text;
    using System.Web;
    
    class Program
    {
        static void Main()
        {
            var text = "Teste de criação no ficheiro";
            var url = "http://translate.google.com/translate_tts?tl=pt&q=";
            url += HttpUtility.UrlEncode(text, Encoding.GetEncoding("utf-8"));
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1";
                client.DownloadFile(url, "mp3CriationTest.mp3");
            }
        }
    }
