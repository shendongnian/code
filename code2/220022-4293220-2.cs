    var str = textbox.Text;
    var words = new[] { "RTS", "RTL" };
    var result = words.AsParallel()
                      .Select(Word => new { Word, Index = str.IndexOf(Word) })
                      .Where(p => p.Index >= 0)
                      .OrderBy(p => p.Index)
                      .Select(p => p.Word)
                      .FirstOrDefault();
    if (result == null)
    {
        // no match
    }
    else
    {
        // match
    }
