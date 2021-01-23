    public class Students :List<Student>
    {
    	public IEnumerable<string> Names
    	{
    		get { return this.Select(x => x.Name); }
    	}
    
    	public IEnumerable<string> Cities
    	{
    		get { return this.Select(x => x.City); }
    	}
    }
    
    class Program
    {
      static void Main(string[] args)
      {
        Students students = new Students();
    
        students.Add(new Student { Age = 20, Name = "Stud1", City = "City1" });
        students.Add(new Student { Age = 46, Name = "Stud2", City = "City2" });
        students.Add(new Student { Age = 32, Name = "Stud3", City = "City3" });
        students.Add(new Student { Age = 34, Name = "Stud4", City = "city4" });
    
    
        foreach (string studentCity in students.Cities)
        {
          Console.WriteLine(studentCity);
        }
    
        foreach (string studentName in students.Names)
        {
          Console.WriteLine(studentName);
        }
    
      } 
    }
