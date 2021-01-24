       static void Main(string[] args)
        {
            string[] answers = new[] { "answer one", "answer two", "answer three", "answer four" };
            Random r = new Random();
            
            int rightAnswer = 2;
            Console.Write("\r" + string.Join(", ", answers));
            for (int i = 0; i < 3; i++)
            {
                    System.Threading.Thread.Sleep(2000);
                    //randomly remove an answer that is not the right one
                    int a = r.Next(answers.Length);
                    while (a == rightAnswer && answers[a][0] != ' ') // dont remove the right answer! dont pick an answer that is already blanked
                        a = r.Next(answers.Length);
                    answers[a] = new string(' ', answers[a].Length); //replace answer with spaces
                    //return to the start of the line and overwrite 
                    Console.Write("\r" + string.Join(", ", answers));
            }
        }
