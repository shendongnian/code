    public class StudentName
    { }
    
    public abstract class Course
    {
        public abstract void AddStudent(StudentName sn, int f);
        public abstract decimal CalculateIncome();
    }
    
    public abstract class WritingCourse : Course
    {
        override public void AddStudent(StudentName sn, int f)
        {
            //Add student
        }
        override public abstract decimal CalculateIncome(); // can only be claculated in concrete
    }
    
    public class BusinessWritCourse : WritingCourse
    {
        override public void AddStudent(StudentName sn, int f)
        { base.AddStudent(sn, 0); }
    
        override public decimal CalculateIncome()
        {
            return (decimal)3.4;//do stuff
        }
    }
    
    public class SewingCourse : Course
    {
        public override void AddStudent(StudentName sn, int f)
        {
            //do stuff
        }
    
        public override decimal CalculateIncome()
        {
            return (decimal)10; //do stuff
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
