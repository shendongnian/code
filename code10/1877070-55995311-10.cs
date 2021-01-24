    public partial class MainWindow : Window
    {
        public readonly List<Emp> Emps = new List<Emp> { new Emp("emp1", "dept1"), new Emp("emp2", "dept1"), new Emp("emp3", "dept2") };
        public readonly List<Dept> Depts = new List<Dept> { new Dept("dept1"), new Dept("dept2"), new Dept("dept3") };
        public MainWindow()
        {
            InitializeComponent();
            EmpsBuDeptDataGrid.ItemsSource = Depts.GroupJoin(Emps,
                d => d.Deptno,
                e => e.Deptno,
                (dept, emps) =>
                new { Deptno = dept.Deptno, Ems = emps.Select(e => e.Name).Aggregate(string.Empty, (s1, s2) => s1 + Environment.NewLine + s2) });
        }
    }
