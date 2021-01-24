        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                //do your stuff....
                context.Database.EnsureCreated();
                var subject1 = new Subject
                {
                    Title = "Physics",
                    Description = "The AB Physics course",
                    GradeEarned = null,
                    GradeOverall = null,
                };
                var subject2 = new Subject
                {
                    Title = "Chemistry",
                    Description = "A AB Chem course",
                    GradeEarned = null,
                    GradeOverall = null,
                };
                var assignment1 = new Assignment
                {
                    Date = new DateTime(2020, 3, 1, 9, 0, 0),
                    Name = "Assignment 1",
                    Description = "Forces and Newton's Laws of Motion",
                    Score = 80,
                    Weight = 0.2,
                    Subject = subject1
                };
                var assignment2 = new Assignment
                {
                    Date = new DateTime(2020, 3, 1, 9, 0, 0),
                    Name = "Assignment 2",
                    Description = "Gravity",
                    Score = 90,
                    Weight = 0.2,
                    Subject = subject1
                };
                var assignment3 = new Assignment
                {
                    Date = new DateTime(2020, 3, 1, 9, 0, 0),
                    Name = "Assignment 3",
                    Description = "Frequency",
                    Score = 70,
                    Weight = 0.2,
                    Subject = subject1
                };
                var exam1 = new Assignment
                {
                    Date = new DateTime(2020, 5, 1, 10, 0, 0),
                    Name = "Exam 1",
                    Description = "The first exam",
                    Score = 85,
                    Weight = 0.6,
                    Subject = subject2
                };
                var exam2 = new Assignment
                {
                    Date = new DateTime(2020, 6, 1, 11, 0, 0),
                    Name = "Exam 2",
                    Description = "The second exam",
                    Score = 75,
                    Weight = 0.6,
                    Subject = subject2
                };
                var assignmentz1 = new Assignment
                {
                    Date = new DateTime(2020, 5, 11, 12, 0, 0),
                    Name = "Assignment 1",
                    Description = "The first Chem grade",
                    Score = 85,
                    Weight = 0.2,
                    Subject = subject2
                };
                context.Subjects.AddRange(new Subject[] { subject1, subject2 });
                context.Assignments.AddRange(new Assignment[] { assignment1, assignment2, assignment3, exam1, exam2 });
                context.SaveChanges();
            }
        }
