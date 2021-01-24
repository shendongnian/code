    string content = Console.ReadLine();
        
    var matchResult = new Regex("(?<='Skills':).*?}]").Matches(content);
        
    var jsonWithNormalizedSkillField = matchResult.Cast<Match>().Select(s => content.Replace(s.Value, s.Value.Replace("'", string.Empty))).FirstOrDefault();
    
    Console.WriteLine(jsonWithNormalizedSkillField);
    Console.ReadLine();
