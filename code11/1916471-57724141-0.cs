    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication51
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("REGION", typeof(string));
                    dt.Columns.Add("NATION", typeof(string));
                    dt.Columns.Add("CITY", typeof(string));
                    dt.Rows.Add(new object[] { "Europe", "Austria", "Wien" });
                    dt.Rows.Add(new object[] { "Europe", "Austria", "Graz" });
                    dt.Rows.Add(new object[] { "APA", "Australia", "Sidney" });
                    foreach (var region in dt.AsEnumerable().GroupBy(x => x.Field<string>("REGION")))
                    {
                        TreeNode regionNode = new TreeNode(region.Key);
                        treeView1.Nodes.Add(regionNode);
                        foreach (var nation in region.GroupBy(x => x.Field<string>("NATION")))
                        {
                            TreeNode nationNode = new TreeNode(nation.Key);
                            regionNode.Nodes.Add(nationNode);
                            foreach (var city in nation.GroupBy(x => x.Field<string>("CITY")))
                            {
                                TreeNode cityNode = new TreeNode(city.Key);
                                nationNode.Nodes.Add(cityNode);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                treeView1.ExpandAll();
            }
        }
    }
