    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication1
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			string connetionString = null;
    			SqlConnection connection ;
    			SqlDataAdapter adapter ;
    			SqlCommand command = new SqlCommand();
    			SqlParameter param ;
    			DataSet ds = new DataSet();
    
    			int i = 0;
    
    			connetionString = "Data Source=servername;Initial Catalog=PUBS;User ID=sa;Password=yourpassword";
    			connection = new SqlConnection(connetionString);
    
    			connection.Open();
    			command.Connection = connection;
    			command.CommandType = CommandType.StoredProcedure;
    			command.CommandText = "SPCOUNTRY";
    
    			param = new SqlParameter("@COUNTRY", "Germany");
    			param.Direction = ParameterDirection.Input;
    			param.DbType = DbType.String;
    			command.Parameters.Add(param);
    
    			adapter = new SqlDataAdapter(command);
    			adapter.Fill(ds);
    
    			for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    			{
    				MessageBox.Show (ds.Tables[0].Rows[i][0].ToString ());
    			}
    
    			connection.Close();
    		}
    	}
    }
