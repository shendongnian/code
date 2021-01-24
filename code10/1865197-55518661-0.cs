    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace TreeView_SQL_Loader
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                DataTable DT = new DataTable();
    
                SQLiteConnection sql_con = new SQLiteConnection("data source=\"mydatabase.db\"");
                sql_con.Open();
                SQLiteCommand sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = "SELECT * FROM mytable";
                SQLiteDataAdapter DA = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
    
                DA.Fill(DT);
                 
                sql_con.Close();
    
                
                int parentID = 0;
                MakeTree(parentID, treeView1.Nodes, DT);
    
                treeView1.ExpandAll();
            }
    
            public void MakeTree(Int64 parentID, TreeNodeCollection parentNode, DataTable DT)
            {
                foreach (DataRow row in DT.AsEnumerable().Where(x => x.Field<Int64>("Field2") == parentID))
                {
                    string name = row.Field<string>("Field3");
                    Int64 id = row.Field<Int64>("Field1");
                    TreeNode node = new TreeNode(name);
                    parentNode.Add(node);
                    MakeTree(id, node.Nodes, DT);
    
                }
            }
        }
    }
