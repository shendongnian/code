    public class Student : IEquatable<Student>
    {
        public string name { get; set; }
        public int mark { get; set; }
    	
    public bool Equals(Student other)
    	{
    		if (string.Equals(name, other.name) && mark == other.mark)
    		{
    			return true;
    		}
    		
    		return false;
    	}
    }
