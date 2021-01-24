    using System;
    using System.Collections;
    using System.Data;
    using System.Windows.Forms;
    
    namespace UltraGrid
    {
        public partial class Form1 : Form
        {
            DataTable table = new DataTable("Statistics");
    
            public Form1()
            {
                InitializeComponent();
    
                // Create columns to hold sample data.
                var column1 = new DataColumn("Sample", typeof(string));
                var column2 = new DataColumn("Line1", typeof(Int64));
                var column3 = new DataColumn("Line2", typeof(Int64));
                var column4 = new DataColumn("Line3", typeof(Int64));
                
                table.Columns.AddRange(new DataColumn[] { column1, column2, column3, column4 });
    
                var now = DateTime.Now.Ticks;
                var rnd = new Random();
                for (int i = 1; i < 20; i++)
                {
                    table.Rows.Add(new object[] { "Sample" + i.ToString(), now + rnd.Next(999, 3600000)*1000, now + rnd.Next(999, 3600000)*1000, now + rnd.Next(999, 3600000)*1000 });
                }
            }
    
            private void LineChartStyles_Load(object sender, System.EventArgs e)
            {
                this.ultraChart1.Data.DataSource = table;
    
                ultraChart1.Axis.Y.Labels.ItemFormatString = "<MY_VALUE>";
                ultraChart1.Tooltips.FormatString = "<MY_VALUE>";
                var MyLabelHashTable = new Hashtable { { "MY_VALUE", new DateTimeRenderer(table) } };
    
                this.ultraChart1.LabelHash = MyLabelHashTable;
                this.ultraChart1.Data.DataBind();
            }
        }
    }
