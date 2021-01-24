   var link = workSheet.Cells[AnswerRowRange].Formula;
   int index = link.IndexOf(",");
   if (index > 0)
   {
      link = link.Substring(0, index);
   }
   var onemore = link.Substring(11);
   var final = onemore.Substring(0,onemore.Length -1);
   answerList.Add(new SurveyCompetitorAnswer
   {
      MainSurveyId = id,
      Answer = workSheet.Cells[AnswerRowRange].Text,
      DateCreated = DateTime.Now,
      Link = final,
      SurveyQuestionId = item.Id,
      SurveyCompetitorId = comp.Id
   });
working fine now.
