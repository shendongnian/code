    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication54
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<ContentData> data = new List<ContentData>() {
                    new ContentData("Path1\\Path2\\Path3\\File0", 110),
                    new ContentData("Path1\\Path2\\Path4\\File1", 112),
                    new ContentData("Path1\\Path2\\Path4\\File2", 22222),
                    new ContentData("Path1\\Path5\\File3", 2312313),
                    new ContentData("Path6", 0)
                };
                CreateTreeRecursive(data, null, 0);
                treeView1.ExpandAll();
            }
            public void CreateTreeRecursive(List<ContentData> data, TreeNode node, int index)
            {
                var groupData = data.Where(x => x.splitName.Length > index).GroupBy(x => x.splitName[index]).ToList();
                foreach (var group in groupData)
                {
                    TreeNode newNode  = new TreeNode(group.First().splitName[index]);
                    if (node == null)
                    {
                        treeView1.Nodes.Add(newNode);
                    }
                    else
                    {
                        node.Nodes.Add(newNode);
                    }
                    CreateTreeRecursive(group.ToList(), newNode, index + 1);
                }
            }
        }
        public class ContentData
        {
            public string Name { get; set; }
            public string[] splitName { get; set; }
            public int Size { get; set; }
            public ContentData(string name, int size)
            {
                Name = name;
                Size = size;
                splitName = name.Split(new char[] {'\\'}).ToArray();
            }
        }
    }
