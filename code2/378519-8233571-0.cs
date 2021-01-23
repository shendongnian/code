    <asp:DropDownList id="bla" runat="server" 
           DataTextField="FullName" DataValueField="emp_Id" />
    public class Employee
    {
        public int emp_Id;
        public string lastName;
        public string firstName;
    
        public string FullName get{ return firstName + "" + lastName;}
    
        public Employee(int id, string last, string first)
        {
            this.emp_Id = id;
            this.lastName = last;
            this.firstName = first;
        }
    }
