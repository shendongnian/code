    const int PAGE_MAX_CHARS_PER_LINE = 30;
    var message = "this is a really long line and it will make your eyes pop out but I don't know how to present a long line differently.  So you will have to stick with\r\nit.   I think the above line should be long enough\r\n\r\n I would love to see how this turns out.";
    var lines = message.Split(new string [] {"\r\n"}, StringSplitOptions.None);
    var linesCount = lines.Length;
    
    var longLines = lines.Where(i=>i.Length > PAGE_MAX_CHARS_PER_LINE);
    foreach(var l in longLines)
    {
      int numberOfLines = (int)Math.Ceiling((double)l.Length / PAGE_MAX_CHARS_PER_LINE); /// Will need to embed graphics measurement mechanism here?
      linesCount += numberOfLines - 1;
    }
