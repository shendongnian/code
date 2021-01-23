    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        public string EmpSex { get; set; }
        public override bool Equals(object obj)
        {
            Employee other = obj as Employee;
            return null != other
                   && other.EmpId == this.EmpId
                   && other.EmpName == this.EmpName
                   && other.EmpAge == this.EmpAge
                   && other.EmpSex == this.EmpSex;
        }
        public override int GetHashCode()
        {
            return (EmpId + "_" + EmpName + "_" + EmpAge + "_" + EmpSex).GetHashCode();
        }
    }
    bool AreEqual<T>(IEnumerable<T> ls1, IEnumerable<T> ls2)
    {
        return ls1.Count() == ls2.Count() && !ls1.Any(e => !ls2.Contains(e)) && !ls2.Any(e => !ls1.Contains(e));
    }
        void Test()
        {
            Employee e1 = new Employee() { EmpAge = 20, EmpId = 123, EmpName = "XYZ", EmpSex = "M" };
            Employee e2 = new Employee() { EmpAge = 20, EmpId = 1232, EmpName = "XYZ", EmpSex = "M" };
            Employee e3 = new Employee() { EmpAge = 20, EmpId = 1232, EmpName = "XYA", EmpSex = "M" };
            Employee e4 = new Employee() { EmpAge = 20, EmpId = 1232, EmpName = "XYF", EmpSex = "M" };
            List<Employee> ls1 = new List<Employee>{e4, e3, e1, e2};
            List<Employee> ls2 = new List<Employee>{e1, e2, e3, e4};
            bool result = AreEqual(ls1, ls2); // true
            ls1 = new List<Employee>{e4, e3, e1, e3};
            ls2 = new List<Employee>{e1, e2, e3, e4};
            result = AreEqual(ls1, ls2); // false
        }
