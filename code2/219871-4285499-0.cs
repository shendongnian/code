    public string TruncatedQuestion
    {
        get
        {
             if (Question.Length > 10)
                 return Question.Substring(0,10) + "...";
             else
                 return Question;
        }
    }
