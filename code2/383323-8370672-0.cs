    <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="false" Width="80%" ActiveStepIndex="2"
        OnNextButtonClick="Wizard1_NextButtonClick">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Employee Username/Network ID">
                <table border="0">
                    <tr>
                        <td class="InputLabel">
                            Username:
                        </td>
                        <td class="InputControl">
                            <asp:TextBox ID="TextBox1" runat="server" />
                        </td>
                        <td>
                        <span id="errorSpan" runat="server" style="color:Red;"></span>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Manage User">
                <div class="content">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblRole" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="Edit User Role">
                <label for="role">
                    Current Role:
                </label>
                <asp:Label ID="Label1" runat="server" BackColor="#FFFF99" Font-Bold="True" ForeColor="#000099" />
                <asp:RadioButtonList ID="radio1" runat="server" TextAlign="left">
                    <asp:ListItem id="option1" runat="server" Value="Admin" />
                    <asp:ListItem id="option2" runat="server" Value="Contribute" />
                    <asp:ListItem id="option3" runat="server" Value="User" />
                </asp:RadioButtonList>
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Clicked" />
                <span id="infoSpan" runat="server" style="color:Red;"></span>
            </asp:WizardStep>
        </WizardSteps>
        <HeaderTemplate>
            <ul id="wizHeader">
                <asp:Repeater ID="SideBarList" runat="server">
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </HeaderTemplate>
    </asp:Wizard>
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //Set the Wizard Step 0 as the initial wizard step when the page loads
                if (!Page.IsPostBack)
                {
                    Wizard1.ActiveStepIndex = 0;
                }
            }
    
            protected void Button1_Clicked(object sender, EventArgs e)
            {
                //If one of the items is selected AND a username exists in the Username session object update the user role
                if (!String.IsNullOrEmpty(radio1.SelectedValue) && Session["Username"] != null)
                {
                    string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=psspdb;Integrated Security=True";
                    string cmdText = "UPDATE employee SET Role = '" + radio1.SelectedValue + "'" + 
                        "WHERE Username = '" + Session["Username"].ToString() + "'";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.ExecuteScalar();
                            infoSpan.InnerText = String.Format("The users role has been updated to - {0}", radio1.SelectedValue);
                        }
                    }
                }
            }
    
            //Method for checking the existence of the username in the database (retrun true or false)
            private bool CheckUsername(string username)
            {
                string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=psspdb;Integrated Security=True";
                string cmdText = "SELECT Count(*) FROM employee WHERE Username = '" + username + "'";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Open DB connection.
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        // True (> 0) when the username exists, false (= 0) when the username does not exist.
                        return (count > 0);
                    }
                }
            }
    
            protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
            {
                switch (Wizard1.WizardSteps[e.NextStepIndex].ID)
                {
                    case "WizardStep2":
                        string username = TextBox1.Text;
                        string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=psspdb;Integrated Security=True";
    
                        //For checking the user        
                        if (!String.IsNullOrEmpty(username) && CheckUsername(username))
                        {
                            try
                            {
                                Session["Username"] = username; 
    
                                SqlConnection conn = new SqlConnection(connString);
                                conn.Open();
                                string cmdText = "SELECT * FROM employee WHERE Username = @Username";
                                SqlCommand myCommand = new SqlCommand(cmdText, conn);
                                myCommand.Parameters.AddWithValue("@Username", username);
                                DataTable table = new DataTable();
                                SqlDataAdapter adapter = new SqlDataAdapter(myCommand);
                                adapter.Fill(table);
    
                                string name = table.Rows[0]["Name"] as string;
                                string jobtitle = table.Rows[0]["JobTitle"] as string;
                                string role = table.Rows[0]["Role"] as string;
    
                                lblName.Text = name;
                                lblJobTitle.Text = jobtitle;
                                lblRole.Text = role;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
    
                        else
                        {
                            //If the user does not exist or a blank value has been entered
                            //Cancel the nextstep redirection and display an error message in a span
                            e.Cancel = true;
                            errorSpan.InnerText = "The user id specified is blank or does not exist";
                        }
    
                        break;
                    case "WizardStep3":
                        //Simply bind the radio list
                        radio1.SelectedValue = lblRole.Text;
                        break;
                }
            }
        }
    }
