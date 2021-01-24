    using System.Text.RegularExpressions;
    ...
    string FileText = 
      "Hey {UserName}, Congratulations ! you have {Result} this exam. Your score is {Score}.";
    string result = Regex.Replace(FileText, 
       "{[A-Za-z]+}", 
        match => replace.TryGetValue(match.Value.Trim('{', '}'), out var value) 
          ?  value?.ToString()
          : "{???}");           // when we don't have a value
    Console.Write(result); 
