    string input = inputTextBox.Text;
    string[] lines = input.Split(new string[] {"\r\n", "\n"}, StringSplitOptions.None);
    
    List<string> inGame = new List<string>();
    foreach (string l in lines)
    {
        if (!l.Contains("your game!"))
            continue;
        if (l.Contains("joined"))
            inGame.Add(l);
        else if (l.Contains("left"))
            inGame.Remove(l);
    }
