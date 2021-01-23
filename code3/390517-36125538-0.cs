    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Types;
    using BOO;
    using BOFactory;
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    
    namespace DAL
    {
        public class CustomerDAL:ICustomerDAL
        {
            List<ICustomerBO> emplist = new List<ICustomerBO>();
            List<ICustomerBO> llist = new List<ICustomerBO>();
    
    
            public List<ICustomerBO> DBbind()
            {
    
                string connectionstring = ";
    
    
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_databinding";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string locn = reader["location"].ToString();
                    ICustomerBO loc = new  CustomerBO(locn);
                    llist.Add(loc);
                }
                connection.Close();
                return llist;
                 }
    
    
            public int addemployee(ICustomerBO b)
            {
                string connectionstring = "Server= LENOVO\\SQLEXPRESS, Authentication=Windows Authentication, Database= tempdb";
    
    
    
                SqlConnection connection = new SqlConnection(connectionstring);
    
                connection.Open();
    
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_addemployee";
    
                command.Connection = connection;
    
                command.Parameters.AddWithValue("@employeename", b.empname);
                command.Parameters.AddWithValue("@dob", b.dob);
                command.Parameters.AddWithValue("@location", b.location);
                command.Parameters.AddWithValue("@gender", b.gender);
                command.Parameters.AddWithValue("@doj", b.doj);
                command.Parameters.AddWithValue("@experience", b.experience);
                command.Parameters.AddWithValue("@CTC", b.ctc);
                command.Parameters.AddWithValue("@designation", b.designation);
                command.Parameters.AddWithValue("@unithead", b.unithead);
                command.Parameters.AddWithValue("@projectid",b.projectid);
    
                command.Parameters.AddWithValue("@id", 0);
    
                command.Parameters["@id"].Direction = ParameterDirection.Output;
    
                int rowaffected = command.ExecuteNonQuery();
    
    
                connection.Close();
    
                if(rowaffected>0)
                {
                    return rowaffected;
                }
    
                else
                {
                    return 0;
                }                                    
                  }
    
            public bool LOGIN(ICustomerBO l)
            {
                bool flag = false;
    
                string connectionstring = "Data Source=sql1;" + ";" + "user id=;"
                    + "password=tcstvm;";
    
                SqlConnection connection = new SqlConnection(connectionstring);
    
                connection.Open();
    
                SqlCommand command = new SqlCommand();
    
                command.CommandType = CommandType.StoredProcedure;
    
                command.CommandText = "sp_loginview";
    
                command.Connection = connection;
    
                SqlDataReader reader = command.ExecuteReader();
    
                while(reader.Read())
                {
                    string name = reader["UserName"].ToString();
                    string pwd = reader["Password"].ToString();
    
                    if((name==l.name)&&(pwd==l.pwd))
                    {
                        flag = true;
                    }
                }
    
                 connection.Close();
    
                return flag;
    
            }
    
             public List<ICustomerBO> viewallListBO()
            {
    
                string ConnectionString = "";
    
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_viewemp7";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = reader["employeename"].ToString();
                    DateTime dob = Convert.ToDateTime(reader["dob"]);
                    string locn = reader["location"].ToString();
                    string gender = reader["gender"].ToString();
                    DateTime doj = Convert.ToDateTime(reader["doj"]);
                    int exp = Convert.ToInt32(reader["experience"]);
                    int ctc = Convert.ToInt32(reader["ctc"]);
                    string desg = reader["designation"].ToString();
                    string head = reader["unithead"].ToString();
                    int proj =Convert.ToInt32( reader["projectid"]);
    
                    ICustomerBO employee=BOFactory.CustomerBOFactory.ADDEMPLOYEE(id, name, dob, locn, gender, doj, exp, ctc, desg, head, proj);
                    emplist.Add(employee);
    
                }
                connection.Close();
                return emplist;
            }
    
    
            public bool EDITCustomer(ICustomerBO bb)
             {
                 bool flag = false;
                 string ConnectionString = "";
    
                 SqlConnection connection = new SqlConnection(ConnectionString);
                 connection.Open();
                 SqlCommand command = new SqlCommand();
                 command.CommandType = CommandType.StoredProcedure;
                 command.CommandText = "sp_editemploye";
                 command.Connection = connection;
                 SqlConnection conn = new SqlConnection();
                 command.Parameters.AddWithValue("@id", bb.id);
                 command.Parameters.AddWithValue("@employeename", bb.empname);
                 command.Parameters.AddWithValue("@dob", bb.dob);
                 command.Parameters.AddWithValue("@location", bb.location);
                 command.Parameters.AddWithValue("@gender", bb.gender);
                 command.Parameters.AddWithValue("@doj", bb.doj);
                 command.Parameters.AddWithValue("@experience", bb.experience);
                 command.Parameters.AddWithValue("@ctc", bb.ctc);
                 command.Parameters.AddWithValue("@designation", bb.designation);
                 command.Parameters.AddWithValue("@unithead", bb.unithead);
                 command.Parameters.AddWithValue("@projectid", bb.projectid);
                 int rowaffected = command.ExecuteNonQuery();
                 connection.Close();
                 if (rowaffected > 0)
                 {
                     flag = true;
                 }
                 return flag;
             }
    
            public bool DeleteEmployee(int bbb)
        {
             bool flag = false;
                string ConnectionString = ;
    
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_deletemploye";
                command.Connection = connection;
    
                command.Parameters.AddWithValue("@id", bbb);
    
                int rowaffected = command.ExecuteNonQuery();
    
                connection.Close();
    
                if (rowaffected > 0)
                { flag = true; }
                return flag;
    }
    
    
            public List<ICustomerBO> viewallListsearchBO(int exo)
            {
                string ConnectionString = "Data Source = ;" +
                  "Initial Catalog = ;"
                  + "User id=;"
                  + "Password=password;";
    
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", exo);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_searchemployee";
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
    
    
    
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string name = reader["employeename"].ToString();
                    DateTime dob = Convert.ToDateTime(reader["dob"]);
                    string locn = reader["location"].ToString();
                    string gender = reader["gender"].ToString();
                    DateTime doj = Convert.ToDateTime(reader["doj"]);
                    int exp = Convert.ToInt32(reader["experience"]);
                    int ctc = Convert.ToInt32(reader["ctc"]);
                    string desg = reader["designation"].ToString();
                    string head = reader["unithead"].ToString();
                    int proj = Convert.ToInt32(reader["projectid"]);
    
                    ICustomerBO employee = BOFactory.CustomerBOFactory.ADDEMPLOYEE(id, name, dob, locn, gender, doj, exp, ctc, desg, head, proj);
                    emplist.Add(employee);
    
                }
                connection.Close();
                return emplist;
            }
        }
    }
    ====================================================================================================================================using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BOO;
    using DAL;
    using Types;
    
    namespace DALFactory
    {
        public class CustomerDALFactory
        {
            public static ICustomerDAL addcustomer()
            {
                ICustomerDAL adddal = new CustomerDAL();
                return adddal;
            }
    
            public static ICustomerDAL LOGIN()
            {
                ICustomerDAL obj = new CustomerDAL();
                return obj;
            }
    
            public static List<ICustomerBO>  viewalllist()
            {
                ICustomerDAL cust=new CustomerDAL();
                List<ICustomerBO> cust1 = cust.viewallListBO();
                return cust1;
            }
    
            public static ICustomerDAL EditCustomer()
            {
                ICustomerDAL d = new CustomerDAL();
                return d;
            }
    
            public static ICustomerDAL deletecustomer()
            {
                ICustomerDAL e = new CustomerDAL();
                return e;
            }      
            public static List<ICustomerBO> DBBIND()
            {
                ICustomerDAL obj5 = new CustomerDAL();
                List<ICustomerBO> emp1 = obj5.DBbind();
                return emp1;
            }
    
            public static List<ICustomerBO> viewsearchlist(int exo)
            {
                ICustomerDAL cust = new CustomerDAL();
                List<ICustomerBO> cust1 = cust.viewallListsearchBO(exo);
                return cust1;
            }
    
    
    
    
    
    
            }
    }
    ============================================================================================================================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Types;
    
    using BOFactory;
    using BLLFactory;
    using DALFactory;
    
    namespace miniproject
    {
        public partial class AddEmployee : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                if (!IsPostBack)
    
                {
    
                    ICustomerBLL bllobj1 = BLLFactory.CustomerBLLFactory.dbind();  //dbind();
                    List<ICustomerBO> list = bllobj1.dbbind();
                    DropDownList5.DataSource = list;
                    DropDownList5.DataTextField = "location";
                    DropDownList5.DataValueField = "location";
                    DropDownList5.DataBind();
    
                }
            }
            protected void TextBox6_TextChanged(object sender, EventArgs e)
            {
                double a = Convert.ToInt32(TextBox6.Text);
    
                if (a == 0)
                {
    
                    RangeValidator3.MaximumValue = "3";
                    RangeValidator3.MinimumValue = "1.5";
    
                    RangeValidator3.Type = ValidationDataType.Double;
                    RangeValidator3.Validate();
                    if (!RangeValidator3.IsValid)
                    {
    
                        RangeValidator3.ErrorMessage = "Enter CTC between 1.5 and 3";
                    }
                }
                else
                {
                    double max = (a * 1.5) + 3;
                    double min = (a * 1.5) + 1.5;
                    RangeValidator3.MaximumValue = max.ToString();
                    RangeValidator3.MinimumValue = min.ToString();
                    RangeValidator3.Type = ValidationDataType.Double;
                    RangeValidator3.Validate();
    
                    if (!RangeValidator3.IsValid)
                    {
                        RangeValidator3.ErrorMessage = "Enter CTC between " + min + " and " + max;
                    }
                }
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                string empname = TextBox1.Text;
                DateTime dob = Convert.ToDateTime(TextBox2.Text);
                string location = DropDownList5.SelectedItem.Text;
                string gender = RadioButtonList3.SelectedItem.Text;
                DateTime doj = Convert.ToDateTime(TextBox4.Text);
                int experience = Convert.ToInt32(TextBox6.Text);
                int ctc = Convert.ToInt32(TextBox5.Text);
                string designation = DropDownList4.SelectedItem.Value;
                string unithead = DropDownList1.SelectedItem.Text;
                int projectid = Convert.ToInt32(DropDownList2.SelectedItem.Text);
    
                ICustomerBLL bllobj = BLLFactory.CustomerBLLFactory.Addcustomer();
    
                ICustomerBO boobj = BOFactory.CustomerBOFactory.Addcustomer( empname,dob, location, gender, doj, experience,ctc,
                 designation, unithead,projectid);
    
                int rowaffected = bllobj.AddCustomer(boobj);
    
                if(rowaffected>0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "call function", "alert('ADDED SUCCESSFULLY.ID=" + rowaffected + "');", true);
                }
                else
                {
                    Response.Write("<script>alert('customer not added ')</script>");
                }
               }
    
            protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
            {
    
            }
    
            protected void TextBox4_TextChanged(object sender, EventArgs e)
            {
    
            }
        }
    }
    ================================================================================================================================
    
                               </tr>
                           </table>
    
      </asp:Content>
    ========================================================================================================================================================
    
    using Types;
    using DALFactory;
    using BOFactory;
    using BLLFactory;
    namespace miniproject
    {
        public partial class EditEmployee : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                {
                    viewdata();
                }
            }
            private void viewdata()
            {
                List<ICustomerBO> emp = DALFactory.CustomerDALFactory.viewalllist();
                GridView1.DataSource = emp;
                GridView1.DataBind();
            }
            protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
    
                GridView1.EditIndex = -1;
                viewdata();
    
            }
    
            protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                Label lbid = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1") as Label;
    
                ICustomerBLL bllobj1 = BLLFactory.CustomerBLLFactory.DeleteEmployee();
                int id = Convert.ToInt32(lbid.Text);
                bool rowaffected = bllobj1.deleteemployee(id);
                GridView1.EditIndex = -1;
                viewdata();
            }
    
            protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
            {
                GridView1.EditIndex = e.NewEditIndex;
                viewdata();
            }
    
            protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
    
    
            }
    
            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
    
    
            }
    
            protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
            {
    
                GridViewRow SelectedRow = GridView1.Rows[e.RowIndex];
                Label lbid = (Label)SelectedRow.FindControl("Label1") as Label;
                string Name = (SelectedRow.FindControl("TextBox1") as TextBox).Text;
                DateTime dob = Convert.ToDateTime((SelectedRow.FindControl("TextBox2") as TextBox).Text);
                string Location = (SelectedRow.FindControl("TextBox3") as TextBox).Text;
                string gender = (SelectedRow.FindControl("TextBox4") as TextBox).Text;
                DateTime doj = Convert.ToDateTime((SelectedRow.FindControl("TextBox5") as TextBox).Text);
                int exp = Convert.ToInt32((SelectedRow.FindControl("TextBox6") as TextBox).Text);
                int ctc = Convert.ToInt32((SelectedRow.FindControl("TextBox7") as TextBox).Text);
                string Designation = (SelectedRow.FindControl("TextBox8") as TextBox).Text;
                string Headid = (SelectedRow.FindControl("TextBox9") as TextBox).Text;
                int projid = Convert.ToInt32((SelectedRow.FindControl("TextBox10") as TextBox).Text);
    
                int id = int.Parse(lbid.Text);
                string name = Name.ToString();
                DateTime dob1 = Convert.ToDateTime(dob);
                string locn = Location.ToString();
                string gen = gender.ToString();
                DateTime doj1 = Convert.ToDateTime(doj);
                int expr = Convert.ToInt32(exp);
                int ctc1 = Convert.ToInt32(ctc);
                string desg = Designation.ToString();
                string head1 = Headid.ToString();
                int proj1 = Convert.ToInt32(projid);
    
                ICustomerBO boobj = BOFactory.CustomerBOFactory.EditCustomer(id, name, dob1, locn, gen, doj1, expr, ctc1, desg, head1, proj1);
                ICustomerBLL bllobj = BLLFactory.CustomerBLLFactory.EditEmployee();
                bool success = bllobj.editemployee(boobj);
    
                GridView1.EditIndex = -1;
                viewdata();
    
            }
    
            protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
            {
                GridViewRow SelectedRow = GridView1.SelectedRow;
                Label lbid = (Label)SelectedRow.FindControl("Label1") as Label;
                string Name = (SelectedRow.FindControl("Label2") as Label).Text;
                DateTime dob = Convert.ToDateTime((SelectedRow.FindControl("Label3") as Label).Text);
                string Location = (SelectedRow.FindControl("Label4") as Label).Text;
    
                int projid = Convert.ToInt32((SelectedRow.FindControl("Label11") as Label).Text);
                int id = Convert.ToInt32(lbid.Text);
    
                Session["EmployeeID"] = id;
                Session["EmployeeName"] = Name;
    
                Session["CTC"] = ctc;
                Session["DESIGNATION"] = Designation;
                Session["HEADID"] = Headid;
                Session["PROJECTID"] = projid;
                Response.Redirect("Update.aspx");
            }
        }
    }
    
    ==================================================================================================================================
    <%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="miniproject.EditEmployee" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    
        <div  style="margin: left:25%">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EmployeeName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("empname") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("empname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateOfBirth">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("dob") %>'></asp:TextBox>
    
                <asp:CommandField EditText="Select" HeaderText="Action" ShowSelectButton="True" />
                <asp:CommandField EditText="Delete" HeaderText="Action" ShowDeleteButton="True" />
                <asp:CommandField HeaderText="Action" ShowEditButton="True" />
            </Columns>
    
        </asp:GridView>
            </div>
    
    </asp:Content>
    ===================================================================================================================================================================
    
    
    
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    
    namespace DAL
    {
        public class DBUtility
        {
            public static SqlConnection getconnection()
            {
    
               SqlConnection dbconnection = null;
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["constr"];
                if(settings!=null)
                {
                    string str = settings.ConnectionString;
                    dbconnection = new SqlConnection(str);
                }
                return dbconnection;
            }
        }
    }
    ============================================================================================================================
     public int updatesupplier(ISupplierBO objBO)
         {
             int ret = 0;
             SqlConnection conn = DBUtility.getconnection();
             conn.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "sp_Updatesupplier";
             cmd.Connection = conn;
    
             cmd.Parameters.AddWithValue("@Supplierid",objBO.Suplierid);
             cmd.Parameters.AddWithValue("@Companyname", objBO.Companyname);
             cmd.Parameters.AddWithValue("@Contactname", objBO.Contactname);
             cmd.Parameters.AddWithValue("@Companyaddress", objBO.Companyaddress);
             cmd.Parameters.AddWithValue("@City", objBO.City);
             cmd.Parameters.AddWithValue("@Country", objBO.Country);
             cmd.Parameters.AddWithValue("@Homepage", objBO.Homepage);
             cmd.Parameters.AddWithValue("@Contactno", objBO.Contactno);
             cmd.Parameters.AddWithValue("@Emailaddress", objBO.Emailaddress);
             cmd.Parameters.AddWithValue("@Bankdetails", objBO.Bankdetails);
             cmd.Parameters.AddWithValue("@Accountno", objBO.Accountno);
             ret = cmd.ExecuteNonQuery();
             conn.Close();
    
             return ret;
    
         }
    
    ======================================================================================================================================
    <connectionStrings>
        <add name="constr" connectionString="Data Source=sql01;Initial Catalog=dbtemp;User ID=vishal;Password=mahesh" providerName="System.Data.SqlClient"/>
      </connectionStrings>
    =====================================================================================================================================
    
            <asp:TemplateField HeaderText="UnitHead">
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("unithead") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProjectID">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("projectid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    
    </asp:GridView>
            <asp:Label ID="Label12" runat="server" Text="Enter ID to search"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" PageIndex="5" AllowPaging="True" PageSize="5">
    
    
    
    ===================================================================================================================================
    
    using Types;
    using DALFactory;
    using BOFactory;
    
    namespace miniproject
    {
        public partial class ViewEmployee : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                BindData();
            }
    
            protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindData();
            }
            private void BindData()
            {
                List<ICustomerBO> emp = DALFactory.CustomerDALFactory.viewalllist();
                GridView1.DataSource = emp;
                GridView1.DataBind();
    
    
    
                }
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                int x = Convert.ToInt16(TextBox1.Text);
                List<ICustomerBO> empc = DALFactory.CustomerDALFactory.viewsearchlist(x);
                GridView2.DataSource = empc;
                GridView2.DataBind();
            }
        }
    }
