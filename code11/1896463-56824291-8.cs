    public interface IMyAppContext
    {
        IList<Question> GetAllQuestions();
        int AddQuestion(Question question);
        int UpdateQuestion(Question question);
        int DeleteQuestion(Question question);
    }
