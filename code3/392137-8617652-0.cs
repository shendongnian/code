    #region USING DICTIONARY TO STORE CLASS OBJECTS (check employee existence and print manager's name)
    public class employee
    {
        public string empname { get; set; }
        public string location { get; set; }
        public double kinid { get; set; }
        public double managerKin { get; set; }
        //public override bool Equals(object obj) // ANY OF THE TWO EQUALS METHOD WORKS.
        //{
        //    employee otheremployee;
        //    otheremployee = (employee)obj;
        //    return (otheremployee.kinid == this.kinid && otheremployee.location == this.location && otheremployee.empname == this.empname && otheremployee.managerKin == this.managerKin);
        //}
        public override bool Equals(object obj)   //When Running this entire code, put a break-point on both the Equals() and GetHashCode() methods, and see the execution flow.
        {
            employee otheremployee;
            otheremployee = (employee)obj;
            return (obj.GetHashCode() == otheremployee.GetHashCode());
        }
        public override int GetHashCode()    //When Running this entire code, put a break-point on both the Equals() and GetHashCode() methods, and see the execution flow.
        {
            //int temp = base.GetHashCode(); // DONT USE THIS
            //return base.GetHashCode();
            int temp = empname.GetHashCode() + location.GetHashCode() + kinid.GetHashCode() + managerKin.GetHashCode();
            return temp;
        }
    }
    public class manager
    {
        public string managername { get; set; }
        public double kinid { get; set; }
       
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
    public class program
    {
        public static void Main()
        {
            employee emp = new employee();
            employee emp2 = new employee();
            manager mng = new manager();
            manager mng2 = new manager();
            emp.empname = "Deepak";
            emp.location = "Pune";
            emp.kinid = 36885;
            emp.managerKin = 007;
            emp2.empname = "Astha";
            emp2.location = "Pune";
            emp2.kinid = 30000;
            emp2.managerKin = 001;
            mng.kinid = 007;
            mng.managername = "Gaurav";
            mng2.kinid = 001;
            mng2.managername = "Surya";
            Dictionary<employee, manager> relations = new Dictionary<employee, manager>();
            relations.Add(emp, mng); // put a BreakPoint here and see the execution flow
            relations.Add(emp2, mng2);// put a BreakPoint here and see the execution flow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Employee details are :");
            foreach (var element in relations)
                Console.WriteLine(" \n Employee Name : {0} \n Location : {1} \n Employee KinId : {2} \n Manager's KinId : {3} ",
                    element.Key.empname, element.Key.location, element.Key.kinid, element.Key.managerKin);
            Console.WriteLine("Enter the details of the Employee..");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nEmployee Name : "); string ename = Console.ReadLine();
            Console.Write("Location : "); string elocn = Console.ReadLine();
            Console.Write("Employee KinId : "); double ekinid = Convert.ToDouble(Console.ReadLine());
            Console.Write("Manager's ID : "); double emngr = Convert.ToDouble(Console.ReadLine());
            employee emp1 = new employee();
            emp1.empname = ename;
            emp1.location = elocn;
            emp1.kinid = ekinid;
            emp1.managerKin = emngr;
            int i = 0; // This variable acts as a indicator to find whether the Employee Key exists or not.
            if (relations.ContainsKey(emp1)) //Put a break point here and see the execution flow.
            {
                Console.WriteLine("the Employee : {0} exists..", emp1.empname);
                Console.WriteLine("the Employee reports to the following manager : {0} \n and the Manager's KinId is {1}.", (relations[emp1]).managername, relations[emp1].kinid);
                i = 1;
                Console.ReadLine();
            }
            if (i == 0)
            {
                Console.WriteLine("the details of the employee named {0} does not exist !!", emp1.empname);
                Console.ReadLine();
            }
    #endregion
