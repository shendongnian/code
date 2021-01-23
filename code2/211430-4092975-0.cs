    public static void Main() {
                Stopwatch w = new Stopwatch();
                string input = "????????";
                w.Start();
                bool allQuestionMarks;
                for (int i = 0; i < 10; ++i ) {
                    allQuestionMarks = input == new string('?', input.Length);
                }
                w.Stop();
                Console.WriteLine("String way {0}", w.ElapsedTicks);
    
    
                w.Reset();
                w.Start();
                for (int i = 0; i < 10; ++i) {
                    allQuestionMarks = input.All(c => c=='?');
                }
                Console.WriteLine(" Linq way {0}", w.ElapsedTicks);
                Console.ReadKey();
            }
