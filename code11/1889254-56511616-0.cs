    public partial class Form1 : Form
    {
        private DataTable dt;
        private DataTable dtExpanded;
        public Form1()
        {
            InitializeComponent();
            LoadTable();
            LoadExpandedTable();
        }
        //Dosage Drug            Patient
       private void LoadTable()
        {
            dt = new DataTable();
            using (SqlConnection cn = new SqlConnection("Your connection string"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From DrugDoses", cn))
                {
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }
            dataGridView1.DataSource = dt;
        }
        private void LoadExpandedTable()
        {
            dtExpanded = new DataTable();
            dtExpanded.Columns.Add("Dose");
            dtExpanded.Columns.Add("Drug");
            dtExpanded.Columns.Add("Patient");
            foreach (DataRow r in dt.Rows)
            {
                string s = (string)r["Drug"];
                if(s.Contains(","))
                {
                    string[] splitName = s.Split(',');
                    foreach (string drug in splitName)
                    {
                        DataRow newRow = dtExpanded.NewRow();
                        newRow.ItemArray = new Object[] { r["Dosage"], drug , r["Patient"]};
                        dtExpanded.Rows.Add(newRow);
                    }
                }
                else
                {
                    dtExpanded.Rows.Add(r.ItemArray);
                }
            }
            dataGridView2.DataSource = dtExpanded;
        }
    }
