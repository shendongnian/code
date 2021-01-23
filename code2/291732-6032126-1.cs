    Class Employee : IComparable
    {
        public string name;
        public string DateOFJoining; //Please note here date is in string format
    
        public int CompareTo(object obj) {
            if(obj is Employee) {
                Employee= (Employee) obj;
    
                return Convert.ToDateTime(DateOfJoining).CompareTo(Convert.ToDateTime(e.DateOfJoining));
            }
            
            throw new ArgumentException("object is not an Employee");    
        }
    }
