      class Program
      {
        static void Main(string[] args)
        {
          var testDateAndTime = DateTime.Now;
    
          var lessons = new Lesson[] {
            new Lesson { Title="A", Subject="English", AddedDate = DateTime.Now.AddMinutes(1)},
            new Lesson { Title="AA", Subject="English", AddedDate = DateTime.Now.AddDays(2)},
            new Lesson { Title="AAA", Subject="English", AddedDate = DateTime.Now.AddDays(3)},
            new Lesson { Title="AAAA", Subject="English", AddedDate = DateTime.Now.AddDays(4)},
            new Lesson { Title="AAAAA", Subject="English", AddedDate = testDateAndTime},
            new Lesson { Title="B", Subject="German", AddedDate = DateTime.Now.AddMinutes(5)},
            new Lesson { Title="BB", Subject="German", AddedDate = DateTime.Now.AddDays(6)},
            new Lesson { Title="BBB", Subject="German", AddedDate = DateTime.Now.AddDays(7)},
            new Lesson { Title="BBBB", Subject="German", AddedDate = DateTime.Now.AddDays(8)},
            new Lesson { Title="BBBBB", Subject="German", AddedDate = testDateAndTime}
          };
    
          var groupedLessons = from l in lessons
                               group l by l.AddedDate into g
                               select new { AddedDate = g.Key, Lessons = g };
    
          foreach (var k in groupedLessons)
          {
            Console.WriteLine("Added Date: " + k.AddedDate);
            foreach (var l in k.Lessons)
            {
              Console.WriteLine("\t Lesson Title: " + l.Title);
            }
          }
    
        }
      }
    
      public class Lesson
      {
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime AddedDate { get; set; }
      }
