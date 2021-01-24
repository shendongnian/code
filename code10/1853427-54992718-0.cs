    class Program {
        static void Main(string[] args) {
            string input = "";
            List<List<int>> answers = new List<List<int>>();
            int questionsCount = ReadInt32("The number of questions: ");
            for (int i = 0; i < questionsCount; i++) {
                answers.Add(new List<int>());
            }
            while (input == "" || input == "y") {
                for (int i = 0; i < answers.Count; i++) {
                    List<int> a = answers[i];
                    a.Add(ReadInt32($"Question [{i}]: "));
                }
                input = Read("Continue (y/n)? ").ToLower();
            }
            WriteLine("End of input!");
            for (int i = 0; i < answers.Count; i++) {
                List<int> a = answers[i];
                Write($"Average for question[{i}]: {a.Average()}\n");
            }
            ReadKey();
        }
        static string Read (string a) {
            Write(a);
            return ReadLine();
        }
        static int ReadInt32 (string a = "") {
            Write(a);
            return ToInt32(ReadLine());
        }
    }
