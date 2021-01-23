    public class Student
    {
    	public string name; 
    	public int StudentId; 
    }
    
    void Main()
    {
    	Student[] Students = 
		new Student[] 
			{ 
				new Student { name="a", StudentId = 0}, 
				new Student { name="b", StudentId = 0}, 
				new Student { name="c", StudentId = 0}, 
				new Student { name="d", StudentId = 0}
			};
    	
    	var studentsList = Students.Select(t => t);
    	
    	int newStudentID = 10001;
    	foreach(var s in studentsList)
    	{      
    	   s.StudentId = newStudentID;            
    	   newStudentID = newStudentID + 1;   
    	}
    	
    	foreach(var s in studentsList)
    	{      
    	   System.Console.WriteLine(s.name + ": " + s.StudentId.ToString());
    	}
    }
