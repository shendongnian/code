    class TestViewModel
    {
        public readonly List<Emp> Emps = new List<Emp> { new Emp("emp1", "dept1"), new Emp("emp2", "dept1"), new Emp("emp3", "dept2") };
        public readonly List<Dept> Depts = new List<Dept> { new Dept("dept1"), new Dept("dept2"), new Dept("dept3") };
        public ObservableCollection<EmpsByDept> EmpsByDepts { get; private set; }
        public TestViewModel()
        {
            EmpsByDepts = new ObservableCollection<EmpsByDept>(Depts.GroupJoin(Emps, 
                d => d.Deptno, 
                e => e.Deptno, 
                (dept, emps) => 
                new EmpsByDept(dept.Deptno, emps.Select(e => e.Name))));
        }
    }
