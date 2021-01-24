        class Book
        {
            readonly List<double> grades;
            public Book() : this(Array.Empty<double>())
            {
            }
            
            public Book(IEnumerable<double> grades)
            {
                this.grades = grades.ToList();
            }
        
            public void AddGrade(double grade)
            {
                grades.Add(grade);
            }
        }
