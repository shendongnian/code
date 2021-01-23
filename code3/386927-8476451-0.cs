    public string GetAnswerTypeText(MyCompany.CoreLib.Main.ChallengeQuestion challengeQuestion)
    {
       if (challengeQuestion.AnswerType.Equals("DateTime"))
       {
           returns "some text";
       }
       else
       {
           returns "some other text";
       }
    }
