        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { First = "Svetlana", Last = "Omelchenko", ID = 111, Scores = new List<int> { 97, 92, 81, 60 } });
            students.Add(new Student { First = "Svetlana", Last = "Omelchenko", ID = 111, Scores = new List<int> { 75, 84, 91, 39 } });
            for (int i = 0; i < students.Count; i++)
            {
                Student item = students[i];
                List<int> scores = item.Scores;
                int max = SortGetMax(scores);
                Debug.WriteLine(max);
            }
        }
        public static int SortGetMax(List<int> arrays)
        {
            int max = 0;
            for (int i = 0; i < arrays.Count; i++)
            {
                if (arrays[i] > max)
                {
                    int flag = arrays[i];
                    arrays[i] = max;
                    max = flag;
                }
            }
            return max;
        }
