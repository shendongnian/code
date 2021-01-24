    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    using CsvHelper;
    
    using System.IO;
    
    namespace Stack_Test
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var path = @"C:\Temp\MYTABLE.csv";
            DataTable dt = readCSV(path);
            foreach(DataRow row in dt.Rows)
            {                
                foreach(DataColumn col in dt.Columns)
                {
                    if (row.Field<String>(col) == String.Empty)
                    {
                        row.SetField(col, DBNull.Value); //row.SetField(col, "NULL"); // Or set the value to any string value of your choice
                    }
                }
            }            
            SqlConnection conn = new SqlConnection("Data Source=localhost; User ID = sa; Password = 'Mon#2017'; Initial Catalog=OIT-DB; Integrated Security=SSPI");            
            using (var command = new SqlCommand("InsertTable", conn) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.Add(new SqlParameter("@myTableType", dt));
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                dt.Clear();                                                    
            }
            using(var command = new SqlCommand("Select * from PRODUCTS", conn) { CommandType = CommandType.Text})
            {                
                SqlDataReader rdr = command.ExecuteReader();              
                dt.Load(rdr);
                dataGridView1.DataBindings.Clear();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();                
                dt.Dispose();
                command.Dispose();
                conn.Close();
                conn.Dispose();
            }            
        } // End button1_Click
