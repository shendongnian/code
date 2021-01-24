var lowerCaseMessage = messageToSend.ToLower(); 
var containsBadWord = purgeWords.Any(badword => lowerCaseMessage.Contains(badword));
example:
    class Program
    {
        static List<string> purgeWords = new List<string> { "badword", "anotherBadWord" };
        static void Main(string[] args)
        {
            var message = "a string containing badword";
            Console.WriteLine(CheckMessage(message));
        }
        static bool CheckMessage(string messageToSend)
        {
            var lowerCaseMessage = messageToSend.ToLower();
            return purgeWords.Any(badword => lowerCaseMessage.Contains(badword));
        }
    }
Result: `True`
