     string case1 = "";
     currLine = sr.ReadToEnd();
     string[] splited = Regex.Split(currLine, "~~~~~~~~~~~~~~");
     case1 = splited[0];
     string pattern1 = "audit;failure";
     if (Regex.IsMatch(case1, pattern1)){
     console.writeline("success"!);
    }
