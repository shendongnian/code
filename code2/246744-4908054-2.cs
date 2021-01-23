    string text = ...
    
    var lines = from line in text.Split
                     (new[] { Environment.NewLine }, StringSplitOptions.None)
                select line.Contains("elit") ? "enim vehicula pellentesque." : line;
    
    string replacedText = string.Join(Environment.NewLine, lines.ToArray());
