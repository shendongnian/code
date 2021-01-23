     protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var Employee = new { EmpID = 1, EmpName = "Rahul Jain", Department = "IT", Age = 33, Address = "Hello" };
                var customerList = (new[] { Employee }).ToList();
                customerList.Add(new { EmpID = 2, EmpName = "Sheetal Jain", Department = "IT", Age = 33, Address = "Hello" });
                GridView1.DataSource = customerList;
                GridView1.DataBind();
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                var Employee = new { EmpID = 1, EmpName = "Rahul Jain", Department = "IT", Age = 33, Address = "Hello" };
                var customerList = (new[] { Employee }).ToList();
                customerList.Add(new { EmpID = 2, EmpName = "Sheetal Jain", Department = "IT", Age = 33, Address = "Hello" });
                customerList.Add(new { EmpID = 2, EmpName = "Minakshi Jain", Department = "IT", Age = 33, Address = "Hello" });
                GridView1.DataSource = customerList;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
