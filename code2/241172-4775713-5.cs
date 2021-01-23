    class Quiz
    {
        private Dictionary<int,string> _questions;
        
        public Quiz(string questionsFileName)
        {
            LoadQuestions(questionsFileName);
        }
        public string PoseQuestion(int number)
        {
            Console.WriteLine(_questions[number]);
        }
        private LoadQuestions(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            _questions = new Dictionary<int, string>();
            foreach (var line in lines)
            {
                var parts = line.Split(new[] {". "}, StringSplitOptions.RemoveEmptyEntries);
                var number = Int32.Parse(parts[0]);
                _questions.Add(number, parts[1]);
            } 
        }
    }
