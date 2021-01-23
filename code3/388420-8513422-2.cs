    public class ExamProduced
    {
        public int ExamID { get; set; }
        public DateTime Date { get; set; }
        public int Seed { get; set; }
        public ExerciseCollection Exercises { get; private set; }
        
        public static ExamProduced ParseElement(XElement answersElement)
        {
            if (answersElement == null) throw new ArgumentNullException("answersElement");
            if (answersElement.Name != "Answers") throw new ArgumentException("element must be an <Answers> element");
            
            return new ExamProduced
            {
                ExamID = (int)answersElement.Attribute("ExamID"),
                Date = (DateTime)answersElement.Attribute("Date"),
                Seed = (int)answersElement.Attribute("Seed"),
                Exercises = ExerciseCollection.ParseElement(answersElement),
            };
        }
    }
    
    public class ExerciseCollection : ReadOnlyCollection<Exercise>
    {
        private ExerciseCollection(IEnumerable<Exercise> exercises) : base(exercises.ToList()) { }
        
        internal static ExerciseCollection ParseElement(XElement answersElement)
        {
            var exercises =
                from objective in answersElement.XPathSelectElements("Summary/Objective")
                join answer in answersElement.Elements("Answer")
                    on (int)objective.Attribute("ID") equals (int)answer.Attribute("ObjectiveID")
                    into answers
                where answers.Any()
                select Exercise.ParseElements(objective, answers);
    
            return new ExerciseCollection(exercises);
        }
    }
    
    public class Exercise
    {
        public int Quantity
        {
            get { return Answers != null ? Answers.Count : 0; }
        }
        public Decimal Score { get; set; }
        public bool IsMakeUp { get; set; }
        public AnswerCollection Answers { get; private set; }
        
        internal static Exercise ParseElements(XElement objective, IEnumerable<XElement> answerElements)
        {
            return new Exercise
            {
                IsMakeUp = (bool)objective.Attribute("MakeUp"),
                Score = objective.Elements("Details").Select(e => (decimal)e.Attribute("Result")).Last(),
                Answers = AnswerCollection.ParseElements(answerElements),
            };
        }
    }
    
    public class AnswerCollection : ReadOnlyCollection<Answer>
    {
        private AnswerCollection(IEnumerable<Answer> answers) : base(answers.ToList()) { }
        public Decimal Score { get; private set; }
        
        internal static AnswerCollection ParseElements(IEnumerable<XElement> answerElements)
        {
            var answers =
                from answerElement in answerElements
                select Answer.ParseElement(answerElement);
            
            return new AnswerCollection(answers);
        }
    }
    
    public class Answer
    {
        public bool IsCorrect { get; set; }
        
        internal static Answer ParseElement(XElement answerElement)
        {
            return new Answer
            {
                IsCorrect = (bool)answerElement.Attribute("IsCorrect"),
            };
        }
    }
