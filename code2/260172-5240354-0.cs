    SPLinqDataContext dc = new SPLinqDataContext(SPContext.Current.Web.Url);
    
    EntityList<QuizItem> Answers = dc.GetList<QuizItem>("Quiz");
    EntityList<QuestionsItem> Questions = dc.GetList<QuestionsItem>("Questions");
    
    int iCorrectAnswers = (from q in Questions
                from a in Answers
                where (q.Question == a.Question) && (q.CorrectAnswer == a.Answer)
                select a).Count();
    
    int iWrongAnswers = (from q in Questions
                            from a in Answers
                            where (q.Question == a.Question) && (q.CorrectAnswer != a.Answer)
                            select a).Count();
