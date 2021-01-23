    public partial class Form1 : Form
    {
        public static DataSet myDataSet { get; set; }
        public Form1()
        {
            InitializeComponent();
            Class1 c1 = new Class1();
            Class2 c2 = new Class2();
        }
    }
    class Class1
    {
        public Class1()
        {      
            //fill dataSet (add new table and some example rows):
            DataTable table = new DataTable("table1");
            table.Columns.Add("Column1", typeof(string));
            table.Rows.Add("item 1");
            table.Rows.Add("item 2");
            Form1.myDataSet = new DataSet();
            Form1.myDataSet.Tables.Add(table);
        }
    }
    class Class2
    {
        public Class2()
        {
            //show dataSet results:
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in Form1.myDataSet.Tables["table1"].Rows)
            {
                sb.AppendLine(dr[0].ToString());
            }
            //show:
            System.Windows.Forms.MessageBox.Show(sb.ToString());
        }
    }
