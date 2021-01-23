        using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication9
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                FillData();
            }
    
            void FillData()
            {
                // 1
                // Open connection
                using (SqlConnection c = new SqlConnection(
                    Properties.Settings.Default.DataConnectionString))
                // 2
                // Create new DataAdapter
                using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM EmployeeIDs", c))
                {
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
    
                    // 4
                    // Render data onto the screen
                    // dataGridView1.DataSource = t; // <-- From your designer
                }
            }
        }
    }
