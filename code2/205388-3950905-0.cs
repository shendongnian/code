    public class Employee
    {
        public Salary Salary {get; set;}
    
        public void GiveRaise()
        {
            Salary.Total *= .25;
            
            if(Salary.Total > 100000)
            {
                Promote();
                GiveBiggerOffice();
            }
            else
            {
                GiveWatch();
            }
        }
    }
