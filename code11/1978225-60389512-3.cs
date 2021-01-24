      private static string DeleteStudentById(string id) {
        var modifiedData = File
          .ReadLines(@"C:\Text\students.txt")
          .Where(line => !string.IsNullOrWhiteSpace(line))
          .Where(line => !line.Split('\')[0].Trim().Equals(id.Trim()))
          .ToList();
        File
          .WriteAllLines(@"C:\Text\students.txt", modifiedData);
      }
 
      private static void DeleteStudents() {
        Console.Write("Enter student ID to delete here: ");
        string id = Console.ReadLine();
        DeleteStudentById(id); 
      } 
