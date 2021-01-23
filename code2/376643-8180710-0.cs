    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TestWinApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }    
            private void Form1_Load(object sender, EventArgs e)
            {
                DataSet dsPlayerList = new DataSet();
                DataTable dt = new DataTable("PlayerList");
                dsPlayerList.Tables.Add(dt);
    
                dt.Columns.Add("ID",typeof(int));
                dt.Columns.Add("Name",typeof(string));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("IP", typeof(string));
    
                DataRow dr = dt.NewRow();
                dr["ID"] = 1;
                dr["Name"] = "Player 1";
                dr["Type"] = "Standard";
                dr["IP"] = "127.0.0.1";
                dt.Rows.Add(dr);
    
                dr = dt.NewRow();
                dr["ID"] = 2;
                dr["Name"] = "Player 2";
                dr["Type"] = "Standard";
                dr["IP"] = "127.0.0.1";
                dt.Rows.Add(dr);
    
                dt.AcceptChanges();
    
                this.dgvPlayerList.AutoGenerateColumns = false;    
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = "Name";
                col.Name = "Name";
                col.HeaderText = "Name";                
                this.dgvPlayerList.Columns.Add(col);
    
                col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = "Type";
                col.Name = "Type";
                col.HeaderText = "Type";    
                this.dgvPlayerList.Columns.Add(col);
    
                this.dgvPlayerList.DataSource = dsPlayerList.Tables["PlayerList"];            
            }        
        }
    }
