    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace TestEntryForm
    {
        public partial class Form1 : Form
        {
            private BindingSource bs = new BindingSource();
            private SqlDataAdapter da = new SqlDataAdapter();
            private string cnc = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Test;Data Source=localhost";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                datadridview.DataSource = bs;
            }
    
            private void SelectCommand(string selectcmd)
            {
                da = new SqlDataAdapter(selectcmd, cnc);
    
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
    
                DataTable table = new DataTable();
    
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                da.Fill(table);
                bs.DataSource = table;
    
                datadridview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
    
            }
    
            private void btnLoad_Click(object sender, EventArgs e)
            {
                SelectCommand(txtQuery.Text);
            }
    
            private void btnUpdate_Click(object sender, EventArgs e)
            {
                da.Update((DataTable)bs.DataSource);
            }
        }
    }
