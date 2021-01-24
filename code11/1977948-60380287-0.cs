    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Visa1 { get; set; }
        public int Visa2 { get; set; }
        public int Homework { get; set; }
        public int FinalExam { get; set; }
        public static Student Parse(string input)
        {
            // Input string cannot be null,
            if (input == null) throw new ArgumentNullException(nameof(input));
            // Input string must have 6 parts
            var data = input.Split();
            if (data.Length < 6) 
                throw new ArgumentException("Input string must contain 6 items");
            // The last 4 parts must be integers
            int visa1, visa2, homework, finalExam;
            if (!int.TryParse(data[2], out visa1))
                throw new ArgumentException("Third item (visa1) must be an integer");
            if (!int.TryParse(data[3], out visa2))
                throw new ArgumentException("Fourth item (visa2) must be an integer");
            if (!int.TryParse(data[4], out homework))
                throw new ArgumentException("Fifth item (homework) must be an integer");
            if (!int.TryParse(data[5], out finalExam))
                throw new ArgumentException("Sixth item (final exam) must be an integer");
            // All validation passed, so create and return a new student
            return new Student
            {
                FirstName = data[0],
                LastName = data[1],
                Visa1 = visa1,
                Visa2 = visa2,
                Homework = homework,
                FinalExam = finalExam
            };
        }
    }
