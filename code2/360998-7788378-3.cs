	public class QuizService
	{
		public QuizDomainObject GetQuiz(int id)
		{
			// using a DI/IoC container is the preferred method instead of access the datacontext directly
			using (EFContainer db = new EFContainer())
			{
				Dictionary<string, int> max = db.Registry
					.Where(x => x.Domain == "Quiz")
					.ToDictionary(x => x.Key, x => Convert.ToInt32(x.Value));
					
				var quiz = from q in db.Quizes
						   where q.Id equals id
						   select new QuizDomainObject()
						   {
								Id = q.Id,
								// all other propeties,
								IsClosed =  // I'm still unclear about the structure of your database and how it interlates, you'll need to figure out the query correctly here
						   };
				
				
				return quiz;
			}
		}
	}
