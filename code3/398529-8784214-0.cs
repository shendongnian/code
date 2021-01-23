     // Create Answer object to save values
     Answer a = new Answer();
     a.QuestionID = dr["QuestionOrder"].ToString();
     a.CorrectAnswer = dr["CorrectAnswer"].ToString();
     a.UserAnswer = answerDropDownList.SelectedValue.ToString();
     ArrayList al = (ArrayList)Session["AnswerList"];
     var oldAnswer = al.ToArray().Where(ans => (ans as Answer).QuestionID == a.QuestionID);
     if (oldAnswer.Count() != 0)
     {
          a = oldAnswer.FirstOrDefault() as Answer;
          a.CorrectAnswer = dr["CorrectAnswer"].ToString();
          a.UserAnswer = answerDropDownList.SelectedValue.ToString();
     }
     else
     {
          al.Add(a);
     }
     //Rest of your code
