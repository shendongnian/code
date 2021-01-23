    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<bool> a = new List<bool>() { true, true, true, false };
            List<bool> b = new List<bool>() { true, true, false, false };
            List<bool> answers = new List<bool>();
            for (int i = 0; i < b.Count; i++)
            {
                answers.Add(a.ElementAt<bool>(i) & b.ElementAt<bool>(i));
            }
             foreach (bool B in answers)
                Console.WriteLine(B);
             Console.ReadKey();
         }
     }
