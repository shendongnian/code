    string input = inputTextBox.Text;
    string[] lines = input.Split(new string[] {"\r\n", "\n"}, StringSplitOptions.None);
    
    Regex joinedLeft = new Regex(@"\{([^{}]*)}.*? has (joined|left) your game!");
    HashSet<string> inGame = new HashSet<string>();
    foreach (string line in lines)
    {
        Match match = joinedLeft.Match(line);
        if (!match.Success)
            continue;
        string name = match.Groups[1].Value;
        string inOrOut = match.Groups[2].Value;
        if (inOrOut == "joined")
            inGame.Add(name);
        else
            inGame.Remove(name);
    }
