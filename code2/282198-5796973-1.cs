    // totally untested
    Dictionary<string, List<string>> sections = new Dictionary<string, List<string>>();
    List<string> section = null;
    
    foreach(string line in GetLines())
    {
       if (IsSectionStart(line))
       {
          string name = GetSectionName(line);
          section = new List<string>();
          sections.Add(name, section);
       }
       else if (IsSectionEnd(line))
       {          
          section = null;  // invite exception when we're lost
       }
       else
       {
          section.Add(line);
       }
    }
    ...
    List<string> foods = sections ["foods"];
