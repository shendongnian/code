    public partial class Form1 : Form
    {
        DataGridView dgv;
        BindingList<User> bList;
        public Form1()
        {
            InitializeComponent();
            dgv = new DataGridView();
            dgv.Location = new Point(20, 20);
            dgv.Size = new Size(600, 200);
            this.Controls.Add(dgv);
            PopulatingDGV();
        }
        private void PopulatingDGV()
        {
            bList = new BindingList<User>();
            bList.Add(new User
            {
                Name = "John",
                SureName = "Walker",
                Email = "john@gmail.com",
                _Role = new Role { RoleID = 1, RoleName = "Role No.1" }
            });
            bList.Add(new User
            {
                Name = "Sara",
                SureName = "Johnson",
                Email = "sj@yahoo.com",
                _Role = new Role { RoleID = 2, RoleName = "Role No.2" }
            });
            //this:
            //dgv.DataSource = new BindingSource { DataSource = bList.Select(s => new { s.Name, s.SureName, s.Email, s._Role.RoleID, s._Role.RoleName }) };
            //that:
            dgv.DataSource = bList.Select(s => new { s.Name, s.SureName, s.Email, s._Role.RoleID, s._Role.RoleName }).ToList();
                               
            dgv.Columns[0].HeaderText = "User`name";
            dgv.Columns[1].HeaderText = "User`s last name";
            dgv.Columns[2].HeaderText = "E - mail";
            dgv.Columns[3].HeaderText = "Role id";
            dgv.Columns[4].HeaderText = "Role name";
        }
    }
    class User
    {
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public Role _Role { get; set; }
    }
    class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
