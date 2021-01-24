    public class HomeController : Controller
    {
        //here I added the controlName variable to the Question, this is better to identify each question by name
        [HttpGet]
        public ActionResult Index()
        {
            List<Question> questions = new List<Question> {
                new Question { ID = 1, name = "What is the capital of Germany", controlName = "germany"},
                new Question {ID =2 , name ="What is the capital of France", controlName = "france"}
            };
            List<Answer> answers = new List<Answer>
            {
                new Answer {Answer1="London", Answer2 = "Berlin", QuestionID= 1},
                new Answer {Answer1="Paris", Answer2 = "Berlin", QuestionID = 2}
            };
            ViewBag.Answers = answers;
            return View(questions);
        }
    }
    //Here am using FormCollection to receive the inputs
    [HttpPost]
    public ActionResult Index(FormCollection questions)
    {
        List<string> controlNames = new List<string>{"germany","france"}; //this is supposed to come from the db if db is in use
        //next create a dictionary of string and string for the controlName and the answer selected for it
        Dictionary<string, string> userAnswer = new Dictionary<string, string>();
        foreach (var controlName in controlNames)
        {
            userAnswer.Add(controlName, questions[controlName]);
        }
           
        //Manipulate the dictionary here and save to the db
        return RedirectToAction("Index");
     }
