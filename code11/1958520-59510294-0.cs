using System;
namespace TextFile1
{
    public class GameText
    {
        public static string firstChapter()
        {
            ... some code ...
        }
    }
}
----- Adventure.cs -----
using TextFile1;
namespace AdventureGame
{
    class Adventure
    {
        static void Main(string[] args)
        {
            // I am telling the player what he/she is going to experience in the game itself.
            TextCaller_1();
        }
        public static void TextCaller_1();
        {
            // You need to initialize an object here
            GameText gameText = new GameText();
            // then call one of its methods
            string text = gameText.firstChapter();
        }
    }
}
