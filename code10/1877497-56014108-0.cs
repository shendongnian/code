c
public static void Main()
{
    List<string> badAnswers = new List<string>() { "It is not so", "Outlook not so good" };
    var _8ball = new Magic8Ball(badAnswers);
    _8ball.Shake();
    Console.WriteLine(_8ball.GetAnswer());
}
