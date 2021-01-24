     namespace ConsoleApplication1
     {   public class Student
    {
    public string id;
     public string name;
     public string familyName;
     public string age;
    }
    class Program
    {
        static void Main(string[] args)
        {
              List<Student> studentList=new List<Student>();
              do
              {
                  // ask user if he wants to add more students
                  Console.WriteLine("do you want to add more? if no please write -No- to terminate and see what you have entered. If yes, please enter -Yes-");
                  string read = Console.ReadLine(); 
                  if (read == "No")
                  {
                      /* You can also access List like this
                       * 
                       * foreach(Student s in studentList)
                      {
                          Console.WriteLine("id of student {0} is: "  s.id);
                        .
                        .
                        .
                      }*/
                      for (int i = 1; i < studentList.Count(); i++)
                      {
                          Console.WriteLine("id of student {1} is{0}: ", studentList[i].id);
                          Console.WriteLine("name of student {1} is{0}: ", studentList[i].name, i);
                          Console.WriteLine("family name of student {1} is{0}: ", studentList[i].familyName, i);
                          Console.WriteLine("age of student {1} is: {0}", studentList[i].age, i);
                      }
                      break;
                  }
                  else {
                      Student s = new Student();
                      //Ask for id
                      s.id = Console.ReadLine();                   
                     //  And same for othre deatil 
                      studentList.Add(s);                   
                  }
              } while (true);
        }
    }
    }
