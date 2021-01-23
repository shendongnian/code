    private static AutoResetEvent answered = new AutoResetEvent(false);
    private static Func<string, bool> questionCorrect = null;
    private static bool? correct;
    static void Main(string[] args)
    {
        int score = 0;
        AskQuestion(ref score,
                    "What is 15 / 3?",
                    TimeSpan.FromSeconds(5),
                    answer =>
                        {
                            decimal value;
                            if (!decimal.TryParse(answer, out value))
                            {
                                Console.WriteLine(
                                    "That was not a valid number");
                                return false;
                            }
                            return (value == 15/3);
                        });
        AskQuestion(ref score,
                    "What is 20  * 2 ?",
                    TimeSpan.FromSeconds(5),
                    answer =>
                        {
                            decimal value;
                            if (
                                !decimal.TryParse(answer,
                                                  out value))
                            {
                                Console.WriteLine(
                                    "That was not a valid number");
                                return false;
                            }
                            return (value == 20*2);
                        });
        Console.WriteLine("Done. Score: {0}", score);
        Console.ReadLine();
    }
    private static void AskQuestion(ref int score, string question, TimeSpan duration, Func<string, bool> validator)
    {
        // Setup
        questionCorrect = validator;
        correct = null;
        answered.Reset();
        // Ask 
        Console.WriteLine(question);
        Thread thread = new Thread(GetQuestion);
        thread.Start();
        // Wait
        answered.WaitOne(duration);
        thread.Abort();
        thread.Join();
        Console.WriteLine(); // Write empty line, otherwise this overwrites the answer. 
        // Validate);
        if (correct.HasValue && correct.Value == true)
        {
            score++;
            Console.WriteLine("Correct");
        }
        else if (correct.HasValue)
        {
            Console.WriteLine("Incorrect");
        }
        else
        {
            Console.WriteLine("Timeout");
        }
    }
    private static void GetQuestion()
    {
        try
        {
            List<char> captured = new List<char>();
            bool answerCaptured = false; 
            while (!answerCaptured)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.KeyChar == '\r' || key.KeyChar == '\n')
                    {
                        answerCaptured = true; 
                        break;
                    }
                    if (key.KeyChar == '\b' && captured.Count > 0)
                    {
                        captured.RemoveAt(captured.Count - 1);
                    }
                    else
                    {
                        captured.Add(key.KeyChar);
                    }
                }
                Thread.Sleep(50);
            }
            string answer = new string(captured.ToArray());
            correct = questionCorrect.Invoke(answer);
            answered.Set();
        }
        catch (ThreadAbortException)
        {
            // will be thrown when the thread times out. 
        }
    }
