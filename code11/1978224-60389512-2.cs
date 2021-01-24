      using System.IO;
      using System.Linq;
      ... 
      private static string FindStudentById(string id) {
        return File
          .ReadLines(@"C:\Text\students.txt")
          .Where(line => !string.IsNullOrWhiteSpace(line)) // to be on the safe side
          .Where(line => line.Split('\')[0].Trim().Equals(id.Trim()))
          .FirstOrDefault() ?? $"No student with id = {id} found";
      }
      private static void SearchStudents() {
        Console.Write("Enter student ID here: ");
        string id = Console.ReadLine();
        Console.WriteLine(FindStudentById(id)); 
      } 
