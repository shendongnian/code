    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Text;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Data.SqlClient;
    using System.Web.UI.HtmlControls;
    public partial class FileIDmasterWorking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            int myint = Convert.ToInt32(TextBox1.Text) + 1;
            for (int i = 1; i < myint; i++)
            {
                Convert.ToString(ListBox2.Items);
                ListBox2.Items.Add(DropDownList1.SelectedItem.ToString() + i.ToString());
            }
        }
        private string GetConnectionString()
        {
            return     System.Configuration.ConfigurationManager.ConnectionStrings["RM_Jan2011ConnectionString"].ConnectionString;
        }
    
        private void InsertRecords(StringCollection sc)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            StringBuilder sb = new StringBuilder(string.Empty);
            **foreach (ListItem item in ListBox2.Items)
            {
                const string sqlStatement = "INSERT INTO FileID(File_Code, Dept_Code) VALUES(@File_Code, @Dept_Code)";
                sb.AppendFormat("{0}('{1}'); ", sqlStatement, item);
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                cmd.Parameters.Add("@File_Code", SqlDbType.VarChar);
                cmd.Parameters["@File_Code"].Value = item.ToString();
                cmd.Parameters.Add("@Dept_Code", SqlDbType.VarChar);
                cmd.Parameters["@Dept_Code"].Value = DropDownList1.Text;
                conn.Open();
                cmd.ExecuteNonQuery();**
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);
                conn.Close();
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();
            foreach (ListItem item in ListBox2.Items)
            {
                {
                    sc.Add(item.Text);
                }
            }
            InsertRecords(sc);
        }
    }
