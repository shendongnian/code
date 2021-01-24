    public class Emp
    {
        public String Name { get; private set; }
        public String Deptno { get; private set; }
        public Emp(String name, String deptno)
        {
            Name = name;
            Deptno = deptno;
        }
    }
    public class Dept
    {
        public String Deptno { get; private set; }
        public Dept(String deptno)
        {
            Deptno = deptno;
        }
    }
    public class EmpsByDept
    {
        public String Deptno { get; private set; }
        public String Emps { get; private set; }
        public EmpsByDept(String deptno, IEnumerable<String> emps)
        {
            Deptno = deptno;
            Emps = ConcatEmps(emps);
        }
        private String ConcatEmps(IEnumerable<String> emps)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var e in emps)
            {
                sb.AppendLine(e);
            }
            return sb.ToString();
        }
    }
