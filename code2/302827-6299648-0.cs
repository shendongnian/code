      public class Student
      {
        public List<Course> Courses { get; set; }
        public List<Grade> Grades { get; set; }
    
        public Dictionary<Course, Grade> CourseGrades { get; set; }
      }
    
      public class Course
      {
        public int Id { get; set; }
      }
    
      public class Grade
      {
        public double Value { get; set; }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          var c0 = new Course() { Id = 0 };
          var c1 = new Course() { Id = 1 };
    
          var students = new List<Student>()
          {
            new Student() { CourseGrades = new Dictionary<Course,Grade>()
            { 
              { c0, new Grade() { Value = 2 } },
              { c1 , new Grade() { Value = 1 } }
            }},
            new Student() { CourseGrades = new Dictionary<Course,Grade>()
            { 
              { c1 , new Grade() { Value = 3 } },
              { c0 , new Grade() { Value = 4 } }
            }},
          };
    
    
          Dictionary<Course, List<Grade>> courseGrades = SelectUnion(students.SelectMany(s => s.CourseGrades), cg => cg.Key, cg => cg.Value);
        }
    
        private static Dictionary<TKey, List<TValue>> SelectUnion<TSource, TKey, TValue>(IEnumerable<TSource> set, Func<TSource, TKey> keyGen, Func<TSource, TValue> valueGen)
        {
          var result = new Dictionary<TKey, List<TValue>>();
    
          foreach (var src in set)
          {
            var key = keyGen(src);
            if (!result.ContainsKey(key))
            {
              result[key] = new List<TValue>();
            }
    
            result[key].Add(valueGen(src));
          }
    
          return result;
        }
