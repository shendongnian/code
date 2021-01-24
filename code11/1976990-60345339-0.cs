    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("job", typeof(string));
                dt.Columns.Add("suffix", typeof(int));
                dt.Columns.Add("operNum", typeof(int));
                dt.Rows.Add(new object[] { "J000027399", 0, 10});
                dt.Rows.Add(new object[] { "J000027399", 0, 20});
                dt.Rows.Add(new object[] { "J000027399", 0, 30});
                dt.Rows.Add(new object[] { "J000027399", 1, 10});
                dt.Rows.Add(new object[] { "J000027399", 1, 20});
                dt.Rows.Add(new object[] { "J000027399", 2, 10});
                dt.Rows.Add(new object[] { "J000027399", 3, 10});
                dt.Rows.Add(new object[] { "J000027399", 4, 10});
                dt.Rows.Add(new object[] { "J000027399", 4, 20});
                dt.Rows.Add(new object[] { "J000027399", 5, 10});
                var groups = dt.AsEnumerable()
                    .OrderBy(x => x.Field<int>("suffix"))
                    .ThenBy(x => x.Field<int>("operNum"))
                    .GroupBy(x => x.Field<int>("suffix"));
                foreach (var group in groups)
                {
                    TreeNode node = new TreeNode(group.Key.ToString());
                    
                    treeView1.Nodes.Add(node);
                    foreach (DataRow row in group)
                    {
                        node.Nodes.Add(row.Field<int>("operNum").ToString());
                    }
                }
                treeView1.ExpandAll();
            }
        }
    }
