    class QuestionRepo : IRepository<Question>
    {
     //call xxxEntites and get/save/delete yourentities here.
    }
    static class RepositoryFactory
    {
     public static IRepository<Question> GetQuestionRepo()
     {
      return new QuestionRepo();
     }
    }
