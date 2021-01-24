    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace DataGridViewDate_58659544_
    {
        public partial class Form1 : Form
        {
            BindingList<dgv1item> dgvData = new BindingList<dgv1item>();
            DataGridView dgv1 = new DataGridView();
            DataGridView dgv2 = new DataGridView();
            public Form1()
            {
                InitializeComponent();
                dgv1.Location = new Point(5,5);
                dgvData.Add(new dgv1item(new DateTime(2019, 5, 1), new DateTime(2020, 5, 1)));
                dgv1.DataSource = dgvData;
                Controls.Add(dgv1);
    
                dgv2.Location = new Point(5, 175);
                dgv2.Columns.Add("datediff", "date difference");
                TimeSpan datedifference = dgvData[0].date2 - dgvData[0].date1;
                dgv2.Rows.Add(datedifference);
                Controls.Add(dgv2);
            }
        }
    
        class dgv1item
        {
            public DateTime date1 { get; set; }
            public DateTime date2 { get; set; }
    
            public dgv1item(DateTime Date1, DateTime Date2)
            {
                date1 = Date1;
                date2 = Date2;
            }
        }
    }
