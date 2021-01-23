        public abstract class Person {
            public int Id { get; set; }
            public abstract string Title { get; set; }
            public abstract string FirstName { get; set; }
            public abstract string LastName { get; set; }
            public DateTime DateOfBirth { get; set; } 
        }
