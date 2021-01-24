public static (string, string) three_Days_before()
{
    Console.Write("72 hours earlier...");
    Console.WriteLine(); //Just a little space.
    string first_sentence = "";
    Console.WriteLine(); //Just a little space.
    string second_sentence = "";
    return (first_sentence, second_sentence);
}
You can optionally give them names too, the underlying type remains the same, but consuming it can be a bit nice as each item can have a name.
public static (string first_sentence, string second_sentence) three_Days_before()
{
    Console.Write("72 hours earlier...");
    Console.WriteLine(); //Just a little space.
    string first_sentence = "";
    Console.WriteLine(); //Just a little space.
    string second_sentence = "";
    return (first_sentence, second_sentence);
}
