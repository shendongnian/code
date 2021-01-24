    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication41
    {
        public partial class Form1 : Form
        {
            DataTable dt = null;
            public Form1()
            {
                InitializeComponent();
                dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Parent_ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Rows.Add(new object[] {1, 0, "Apple"});
                dt.Rows.Add(new object[] {2, 0, "Pear"});
                dt.Rows.Add(new object[] {3, 2, "Grapes"});
                dt.Rows.Add(new object[] {4, 3, "Banana"});
                TreeNode node = new TreeNode("Root");
                treeView1.Nodes.Add(node);
                int parentID = 0;
                MakeTree(parentID, node);
                treeView1.ExpandAll();
            }
            public void MakeTree(int parentID, TreeNode parentNode)
            {
                foreach(DataRow row in dt.AsEnumerable().Where(x => x.Field<int>("Parent_ID") == parentID))
                {
                    string name = row.Field<string>("Name");
                    int id = row.Field<int>("ID");
                    TreeNode node = new TreeNode(name);
                    parentNode.Nodes.Add(node);
                    MakeTree(id, node);
                }
            }
        }
    }
