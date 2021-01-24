    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication62
    {
        public partial class Form1 : Form
        {
            
            public Form1()
            {
                InitializeComponent();
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("File1", "Folder1\\Folder2");
                dict.Add("File2", "Folder1\\Folder2\\Folder3");
                dict.Add("File3", "Folder1");
                dict.Add("File4", "Folder1\\Folder2");
                List<KeyValuePair<string, List<string>>> files = dict.Select(x => new KeyValuePair<string, List<string>>(x.Key, x.Value.Split(new char[] {'\\'}).ToList())).ToList();
                TreeNode root = new TreeNode();
                CreateTree(null, files);
                treeView1.ExpandAll();
            }
            public void CreateTree(TreeNode node, List<KeyValuePair<string, List<string>>> files)
            {
                var folders = files.GroupBy(x => x.Value.First()).ToList();
                foreach (var folder in folders)
                {
                    TreeNode newNode = new TreeNode(folder.Key);
                    if (node == null)
                    {
                        treeView1.Nodes.Add(newNode);
                    }
                    else
                    {
                        node.Nodes.Add(newNode);
                    }
                    List<KeyValuePair<string, List<string>>> child = new List<KeyValuePair<string, List<string>>>();
                    foreach (KeyValuePair<string, List<string>> file in folder)
                    {
                        if (file.Value.Count == 1)
                        {
                            newNode.Nodes.Add(file.Key);
                        }
                        else
                        {
                            KeyValuePair<string, List<string>> newFile = new KeyValuePair<string, List<string>>(file.Key, file.Value.Skip(1).ToList());
                            child.Add(newFile);
                        }
                    }
                    if (child != null)
                    {
                        CreateTree(newNode, child);
                    }
                }
            }
     
        }
    }
