    void Main()
    {
        // The path of the file to write to.
        string filename = "D:\\temp\\Trivia.txt";
    
        var questions = new List<QuestionInfo>() {
            new QuestionInfo("Q1", "A1", 1),
            new QuestionInfo("Q2", "A2", 3),
            new QuestionInfo("Q3", "A3", 3),
            new QuestionInfo("Q4", "A4", 1),
            new QuestionInfo("Q5", "A5", 2),
            new QuestionInfo("Q6", "A6", 1),
            new QuestionInfo("Q7", "A7", 2),
            new QuestionInfo("Q8", "A8", 1),
            new QuestionInfo("Q9", "A9", 3),
            new QuestionInfo("Q10", "A10", 1),
        };
        using (TextWriter tw = new StreamWriter(filename))
        {
            try
            {
                QuestionInfo.WriteCsv(questions, tw);
                Console.WriteLine("Data successfully written to " + filename);
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be written.");
                Console.WriteLine(e.Message);
            }
        }
    }
    
    public class QuestionInfo
    {
        string Question { get; }
        string Answer { get; }
        int Points { get; }
    
        public QuestionInfo(string question, string answer, int points)
        {
            Question = question;
            Answer = answer;
            Points = points;
        }
    
        public void WriteCsv(TextWriter tw)
        {
            tw.WriteLine($"{Question},{Answer},{Points}");
        }
    
        public static void WriteCsv(List<QuestionInfo> questions, TextWriter tw)
        {
            foreach (var question in questions)
            {
                question.WriteCsv(tw);
            }
        }
    }
