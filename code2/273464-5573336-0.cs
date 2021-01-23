        public static List<Student> GetStudents()
        {
            using (var context = new Entities())
            {
                List<Student> myList = (from a in context.Students
                                       select a).ToList();
                return myList;
            }
        }
