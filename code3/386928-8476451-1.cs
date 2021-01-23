    public string GetAnswerTypeText(MyCompany.CoreLib.Main.ChallengeQuestion challengeQuestion)
    {
       if (challengeQuestion.AnswerType.Equals("DateTime"))
       {
           return "some text";
       }
       else
       {
           return "some other text";
       }
    }
