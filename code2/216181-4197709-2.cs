    var nestedDictionary = normalizedResults
        .ToDictionary(x=>x.Respondent,
            x=>nestedDictionary.Where(x2=>x2.Respondent == x.Respondent)
                .ToDictionary(x2=>x2.Admin,
                    x2=>nestedDictionary.Where(x3=>x3.Respondent == x2.Respondent && x3.Admin == x2.Admin)
                        .ToDictionary(x3=>x3.Question, x3=>x3.Answer)));
    //All that mess makes getting to a single value pretty easy:
    var answer = nestedDictionary[1][2][1]; //Respondent 1, Admin 2, Question 1
