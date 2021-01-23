    class Program
    {
        static void Main()
        {
            var processQuestions = new ProcessQuestions();
            processQuestions.StartQuestions();
            processQuestions.PrintAnswers();
            Console.ReadLine();
        }
    }
    public class ProcessQuestions
    {
        NewsSubscriber subscriber1 = new NewsSubscriber("Tim");
        NewsSubscriber subscriber2 = new NewsSubscriber("Bob");
        NewsPublisher publisher = new NewsPublisher();
        public ProcessQuestions()
        {
            publisher.QuestionAsked += subscriber1.Asked;
            publisher.QuestionAsked += subscriber2.Asked;
        }
        public void StartQuestions()
        {
            publisher.PublishQuestion("what is your favourite Newspaper?");
            publisher.PublishQuestion("what is your email?");
            publisher.PublishQuestion("what is your email password?");
        }
        public void PrintAnswers()
        {
            var subs = new[] {subscriber1, subscriber2};
            foreach (var newsSubscriber in subs)
            {
                Console.WriteLine(newsSubscriber.Name + " answers:");
                foreach (var answer in newsSubscriber.Answers)
                {
                    Console.WriteLine(answer);
                }
            }
        }
    }
    public class NewsSubscriber
    {
        private readonly string _name;
        public NewsSubscriber(string name)
        {
            _name = name;
        }
        List<string> _answers = new List<string>();
        public string Name
        {
            get { return _name; }
        }
        public List<string> Answers { get { return _answers; } }
        public void Asked(string question)
        {
            Console.WriteLine(_name + " says: ");
            _answers.Add(Console.ReadLine());
        }
    }
    public class NewsPublisher
    {
        private readonly List<string> _questions = new List<string>();
        public delegate void NotifyObserversHandler(string question);
        public event NotifyObserversHandler QuestionAsked;
        public void PublishQuestion(string question)
        {
            _questions.Add(question);
            Console.Write(question);
            QuestionAsked(_questions[_questions.Count - 1]);
        }
    }
