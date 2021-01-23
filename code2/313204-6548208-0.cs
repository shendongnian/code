    class Student
    {
        protected int grade1, grade2, grade3;
        public Student(int grade1, int grade2, int grade3)
        {
           this.grade1 = grade1;
           this.grade2 = grade2;
           this.grade3 = grade3;
        }
    
        public double Average()
        {
            return (grade1 + grade2 + grade3) / 3;
        }
    
        public double Sum()
        {
            return grade1 + grade2 + grade3;
        }
    }
