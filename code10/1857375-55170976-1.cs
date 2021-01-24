    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
      public static class Program
      {
        private static MongoClient Client;
        private static IMongoDatabase Database;
        private static IMongoCollection<Student> Collection;
    
        public static async Task Main(string[] args)
        {
          Client = new MongoClient();
          Database = Client.GetDatabase("test-index");
          Collection = Database.GetCollection<Student>("students");
    
          var courses1 = new List<Course>()
          {
            new Course { Name = "Math", Teacher = "Bob" }
          }.AsReadOnly();
    
          var courses2 = new List<Course>()
          {
            new Course { Name = "Computer Science", Teacher = "Alice" }
          }.AsReadOnly();
    
          var mark = new Student
          {
            Name = "Mark",
            Courses = courses1,
            Age = 20
          };
    
          var lucas = new Student
          {
            Name = "Lucas",
            Courses = courses2,
            Age = 22
          };
    
          await Collection.InsertManyAsync(new[] { mark, lucas }).ConfigureAwait(false);
    
    
          var model = new CreateIndexModel<Student>(
            Builders<Student>.IndexKeys.Ascending(s => s.Courses));
    
          await Collection.Indexes.CreateOneAsync(model).ConfigureAwait(false);
    
          Console.WriteLine("All done !");
        }
      }
    }
