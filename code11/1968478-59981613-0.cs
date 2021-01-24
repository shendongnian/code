using System.Collections.Generic;
using Newtonsoft.Json;
namespace JsonProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Name = "Jason",
                Subjects = new List<Subject>
                {
                    new Subject
                    {
                        Id = 1,
                        CourseName = "Maths",
                        Score = 70
                    },
                    new Subject
                    {
                        Id = 2,
                        CourseName = "English",
                        Score = 80
                    },
                }
            };
            var json = ToStudentJson(student);
        }
        private static string ToStudentJson(Student student)
        {
            var subjects = new List<Dictionary<string, SubjectBase>>();
            foreach (var subject in student.Subjects)
            {
                var dict = new Dictionary<string, SubjectBase>();
                dict.Add(subject.CourseName, new SubjectBase { CourseName = subject.CourseName, Score = subject.Score });
                subjects.Add(dict);
            }
            var studentJson = new StudentJson
            {
                Name = student.Name,
                Subjects = subjects.ToArray()
            };
            return JsonConvert.SerializeObject(studentJson);
        }
    }
    public class StudentJson
    {
        public string Name { get; set; }
        public Dictionary<string, SubjectBase>[] Subjects { get; set; }
    }
    public class Student
    {
        public string Name { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
    public class Subject : SubjectBase
    {
        public int Id { get; set; }
    }
    public class SubjectBase
    {
        public string CourseName { get; set; }
        public int Score { get; set; }
    }
}
Output:
{
	"Name": "Jason",
	"Subjects": [
		{
			"Maths": {
				"CourseName": "Maths",
				"Score": 70
			}
		},
		{
			"English": {
				"CourseName": "English",
				"Score": 80
			}
		}
	]
}
  [1]: https://jsonformatter.curiousconcept.com/
  [2]: https://i.stack.imgur.com/8q3Ew.png
