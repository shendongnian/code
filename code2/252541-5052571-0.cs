    namespace Person {
        public class Person {
            private String Name;
            private int Age;
            private String Job;
            private Boolean IsMale;
    
            public Person(string name, int age, string job, bool isMale) {
                Name = name;
                Age = age;
                Job = job;
                IsMale = isMale;
            }
        }
    
        public class CollegeStudent : Person {
            public CollegeStudent(string name) : this(name, 18) { }
            public CollegeStudent(string name, int age) : this(name, age, "Student") { }
            public CollegeStudent(string name, int age, string job) : this(name, age, job, true) { }
            public CollegeStudent(string name, int age, string job, bool isMale) : base(name, age, job, isMale) { }
        }
    }
