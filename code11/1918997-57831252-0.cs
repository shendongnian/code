static void Search_Level_2()
{
    bool check = false;
    WriteLine("Search Level 2:\nChecking if sequence {0} is in file...", inputArray[3]);
    foreach (string line in sequences)
    {
        if (check)
        {
            WriteLine("Next line:");
            WriteLine(line);
            break;
        }
        if (line.Contains(inputArray[3]))
        {
            WriteLine("Sequence Found!");
            WriteLine(line);
            check = true;
        }
    }
    if (!check)
    {
        WriteLine("Error: Sequence {0} not found", inputArray[3]);
    }
}
I'm assuming that you want to only report the first occurrence and the line following the match.
