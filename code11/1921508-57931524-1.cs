    public static void Assign<T>(T target,Dictionary<string,string> source)
    {
       var properties = typeof(T).GetProperties();
    
       foreach (var prop in properties)
       {
          if(source.TryGetValue(prop.Name,out var value))
          {
             prop.SetValue(target, value);
          }
       }
    }
    
    private static void Main(string[] args)
    {
       var student = new Student();
       var studentInfo = new Dictionary<string, string>();
       studentInfo["ID"] = "12345";
       studentInfo["FirstName"] = "John";
       studentInfo["LastName"] = "Doe";
       Assign(student, studentInfo);
    }
