    public enum Subjects
    {
        Programming, Design, Administration
    }
    class Program
    {
        static void Main(string[] args)
        {
                        
            var grades = new Dictionary<Subjects, int[]>();
            foreach (Subjects subject in Enum.GetValues(typeof(Subjects)))
            {
                grades.Add(subject, new int[5]);
            }
            // example of use:
            grades[Subjects.Programming][0] = 0;
        }
    }
