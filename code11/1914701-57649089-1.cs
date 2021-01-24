    using System.Windows.Forms;
    using System.Data.SqlClient;
     
    namespace workingwithdataset
    {
        public partial class frmdataset : Form
        {
            public frmdataset()
            {
                InitializeComponent();
            }
            private void frmdataset_Load(object sender, EventArgs e)
            {
                SqlDataAdapter dadapter = new SqlDataAdapter(" select * from student_detail ", " database=student;user=sa;password=wintellect ");
                DataSet dset = new DataSet(); //Creating instance of DataSet
                dadapter.Fill(dset,"student_detail"); // Filling the DataSet with the records returned by SQL statemetns written in sqldataadapter
                dataGridView1.DataSource = dset.Tables["student_detail"]; // Binding the datagridview
            }        
        }
    }
