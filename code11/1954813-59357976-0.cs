static bool MatchesAtLeast(string s, Regex re, int matchCount)
{
    bool success = false;
    int startPos = 0;
    while (!success)
    {
        Match m = re.Match(s, startPos);
        if (m.Success)
        {
            matchCount--;
            success = (matchCount <= 0);
            startPos = m.Index + m.Length;
            if (startPos > s.Length - 2) { break; }
        }
        else { break; }
    }
    return success;
}
static void Main(string[] args)
{
    Regex re = new Regex(@"\s+");
    string s = "Somestreet  155/ EG\t47";
    Console.WriteLine(MatchesAtLeast(s, re, 3)); // outputs True
    Console.ReadLine();
}
