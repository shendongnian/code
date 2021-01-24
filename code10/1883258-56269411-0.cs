    public class Program
    {
    	public static void Main()
    	{
    		IList<Student> studentList1 = new List<Student>()
    		{
    			new Student { name = "aaaaa", mark = 95, },
    			new Student { name = "bbbb", mark = 25, },
    			new Student { name = "ccc",  mark = 80 }
    		};
    
    		IList<Student> studentList2 = new List<Student>()
    		{
    			new Student { name = "aaaaa", mark = 95, },
    			new Student { name = "bbbb", mark = 5, },
    			new Student { name = "ccc",  mark = 80 }
    		};
    
    		bool isEqual = studentList1.SequenceEqual(studentList2, new StudentComparer());
    		Console.WriteLine("Contents in 2 collections are {0}", isEqual ? "equal" : "not equal");
    	}
    }
    
    public class Student
    {
    	public string name { get; set; }
    	public int mark { get; set; }
    }
    
    public class StudentComparer : IEqualityComparer<Student>
    {
    	public bool Equals(Student x, Student y)
    	{
    		//Check whether the compared objects reference the same data. 
    		if (object.ReferenceEquals(x, y))
    			return true;
    
    		//Check whether any of the compared objects is null. 
    		if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
    			return false;
    
    		return string.Equals(x.name, y.name, StringComparison.OrdinalIgnoreCase) && x.mark == y.mark;
    	}
    
    	public int GetHashCode(Student student)
    	{
    		//Check whether the object is null 
    		if (object.ReferenceEquals(student, null))
    			return 0;
    
    		//Get hash code for the name field if it is not null
    		int nameHashCode = !string.IsNullOrEmpty(student.name) ? 0 : student.name.GetHashCode();
    
    		// Get hash code for marks also if its not 0
    		int marksHashCode = student.mark == 0 ? 0 : student.mark.GetHashCode();
    
    		return nameHashCode ^ marksHashCode;
    	}
    }
