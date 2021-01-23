        public class Student
    {
    	public IEnumberable<Class> ClassesIAttend {get; set}
    	...
    }
    
    public class Teacher
    {
    	public IEnumberable<Class> ClassesITeach {get; set;}
    	...
    }
    
    public class Person : BussinesBase
    {
    	//either of these can be null
    	private Student studentPart;
    	private Teacher teacherPart;
    
    	public bool IsTeacher()
    	{
    		return teacherPart != null;
    	}
    }	
