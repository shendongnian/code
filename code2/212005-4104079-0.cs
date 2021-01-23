    using System;
    using System.Collections.Generic;
    
    public class Employee
    {
        private int _id;
        private string _FName;
        private string _MName;
        private string _LName;
        private DateTime _DOB;
        private char _sex;
    
        public int ID { get { return _id; } set { _id = value; } }
        public string FName { get { return _FName; } set { _FName = value; } }
        public string MName { get { return _MName; } set { _MName = value; } }
        public string LName { get { return _LName; } set { _LName = value; } }
        public DateTime DOB { get { return _DOB; } set { _DOB = value; } }
        public char Sex { get { return _sex; } set { _sex = value; } }
    
        public Employee(int id, string fname, string mname, string lname, DateTime dob, char sex)
        {
            ID = id;
            FName = fname;
            MName = mname;
            LName = lname;
            DOB = dob;
            Sex = sex;
        }
    
        public List<Employee> GetEmployeeList()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee(1, "John", "", "Shields", DateTime.Parse("12/11/1971"), 'M'));
            //etc
            return empList;
        }
    }
