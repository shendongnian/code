    public partial class Insertfrm1 : Form
    {
        public OleDbConnection conn;
        public OleDbDataAdapter da;
        public DataSet ds;
        public DataTable dt;
        public OleDbCommand cmd;
        public OleDbDataReader dr;
        public int maxrecords;
        public int pointer;
        static public int cnt;
        public string wid;
        
        public Insertfrm1()
        {
            cnt++;
            InitializeComponent();
        }
        private void Insertfrm1_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\MyWorkers1.mdb");
            conn.Open();
            pointer = 0;
            filldata();
            navigation();
        }
        public void filldata()
        {
            da = new OleDbDataAdapter("select * from tblWorkers", conn);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            maxrecords = dt.Rows.Count;
        }
        public void navigation()
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no Data available");
            }
            else
            {
                txtworkersid.Text = dt.Rows[pointer].ItemArray[0].ToString();
                txtname.Text = dt.Rows[pointer].ItemArray[1].ToString();
                txtjobtitle.Text = dt.Rows[pointer].ItemArray[2].ToString();
            }
        }
        public void clrdata()
        {
            txtworkersid.Clear();
            txtname.Clear();
            txtjobtitle.Clear();
            txtworkersid.Focus();
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtworkersid.Clear();
            txtname.Clear();
            txtjobtitle.Clear();
            txtworkersid.Focus();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            Boolean inc = false;
            if (txtworkersid.Text == "")
            {
                DialogResult sav = MessageBox.Show("The Worker ID is Empty", "Blank Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtname.Text == "")
            {
                DialogResult sav = MessageBox.Show("The Workers Name is Empty", "Blank Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtjobtitle.Text == "")
            {
                DialogResult sav = MessageBox.Show("The Job Title is Empty", "Balnk record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //string cmdstr = "SELECT Workers_ID FROM tblWorkers WHERE (Workers_ID='" + txtworkersid.Text + "')";
                //cmd = new OleDbCommand(cmdstr, conn);
                cmd=new OleDbCommand("SELECT Workers_ID FROM tblWorkers WHERE (Workers_ID='" + txtname.Text + "')",conn);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    if (txtworkersid.Text == dr.GetValue(0).ToString())
                    {
                        DialogResult sav = MessageBox.Show("The Record is Duplicate", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        inc = true;
                        break;
                    }
                    else
                    {
                        dr.NextResult();
                    }
                }
                if (inc == false)
                {
                    string sql = "INSERT INTO tblWorkers(Workers_ID,name,job_title) VALUES ('" + txtworkersid.Text + "','" + txtname.Text + "','" + txtjobtitle.Text + "')";
                    Execute(sql);
                    DialogResult save = MessageBox.Show("Workers Record is saved Sucessfully.");
                    clrdata();
                }
            }
        }
        public void Execute(string sql)
        {
            //throw new NotImplementedException();
            cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            filldata();
        }
               
        private void txtworkersid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                DialogResult num = MessageBox.Show("Only Numbers are allowed", "invalid Key");
            }
        }
    
    }
}
