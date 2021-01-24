    void AskQuestion(string Question, List<string> Answers, int CorrectAnswer, bool tryUntillCorrect = false)
    {
        bool answeredCorrectly = false;
        while(!answeredCorrectly)
        {
            Console.WriteLine("Question: " + Question + "?");
            for(int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine(string.Format("{0}) {1}", i, Answers[i]));
            }
            int UserAnswer = Convert.ToInt32(Console.ReadLine());
            if(UserAnswer == CorrectAnswer)
            {
                Console.WriteLine("Correct (20 mark)");
                return;
            }
            else
            {
                Console.WriteLine("Incorrect!");
                if(!tryUntillCorrect)
                    return;
                Console.WriteLine("Answer you typed in is incorrect so you need to try again!");
            }
        }
    }
