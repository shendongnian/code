    public class Student
    {
    	public Student(string s, string m) 
    	{
    		StudentName = s;
    		MadrakName = m;
    	}
        public string StudentName { get; set; }
        public string MadrakName { get; set; }
    	public override string ToString() { return StudentName; }
    }
