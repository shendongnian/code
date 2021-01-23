        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SO_Forms_Demo
    {
        public partial class FormFIFO : Form
        {
            DataTable _table;
            public FormFIFO()
            {
                InitializeComponent();
    
                _table = new DataTable("fifo");
                _table.Columns.Add(new DataColumn("serialNumber"));
                _table.Columns.Add(new DataColumn("partNumber"));
                _table.Columns.Add(new DataColumn("qty"));
                _table.AcceptChanges();
                _table.Rows.Add(new object[3] { 1, "0001", 20 });
                _table.Rows.Add(new object[3] { 2, "0002", 10 });
                _table.Rows.Add(new object[3] { 3, "0001", 20 });
                _table.Rows.Add(new object[3] { 4, "0002", 10 });
                _table.Rows.Add(new object[3] { 5, "0001", 20 });
                _table.Rows.Add(new object[3] { 6, "0002", 10 });
                _table.AcceptChanges();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                dataGridView1.DataSource = null;
                SumFifo sumFifo = new SumFifo(_table);
                dataGridView1.DataSource = sumFifo.GetAll();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                dataGridView1.DataSource = null;
                SumFifo sumFifo = new SumFifo(_table);
                dataGridView1.DataSource = sumFifo.GetFIFO(textBox1.Text,int.Parse( textBox2.Text));
            }
        }
    }
