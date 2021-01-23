     using System;
     using System.Collections;
    class MyClass
    {
        static void Main(string[] args)
        {
            Context<Teacher> teachersContext  = new Context<Teacher>(100);//contructs a db of 100 teachers
            Context<Student> studentsContext = new Context<Student>(100);//contructs a db of 100 teachers 
            Repository repo = new Repository();
            // set the repository context and get a teacher
            repo.Context = teachersContext;
            Teacher teacher1 = repo.Get<Teacher>(83); //get teacher number 83
            Console.WriteLine("Teacher Id:{0} ", teacher1.Id);
          
            // redirect the repositry context and now get a student
            repo.Context = studentsContext;
            Student student1 = repo.Get<Student>(35); //get student  number 35
        
            Console.WriteLine("Student Id: {0} ", student1.Id);
               
            Console.ReadLine();
        }
