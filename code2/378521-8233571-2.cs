    <asp:DropDownList id="bla" runat="server"  />
    bla.DataSource = employeeList;
    bla.DataTextField = "fullName";
    bla.DataValueField = "emp_Id"
    bla.DataBind();
    public class Employee
    {
        public int emp_Id;
        public string lastName;
        public string firstName;
    
        public string fullName get{ return firstName + " " + lastName;}
    
        public Employee(int id, string last, string first)
        {
            this.emp_Id = id;
            this.lastName = last;
            this.firstName = first;
        }
    }
