	public class QuizController : Controller 
	{
		public ActionResult View(int id)
		{
			// using a DI/IoC container is the preferred method instead of manually creating a service
			var quizService = new QuizService(); 
			QuizDomainObject quiz = quizService.GetQuiz(id);
			
			return View(quiz);
		}
	}
