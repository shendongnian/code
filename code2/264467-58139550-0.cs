    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading.Tasks;
    using System.DirectoryServices;
    using System.Collections.Generic;
    using System.DirectoryServices.ActiveDirectory;
    
    namespace WindowsFormsApp8
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                treeView1.Nodes.Clear();
                string top = string.Format("LDAP://DC={0}", Domain.GetCurrentDomain().Name.Replace(".", ",DC="));
                ADTree tree = null;
    
                Task BuildOUStructure = Task.Factory.StartNew(() =>
                {
                    tree = new ADTree(top);
                });
    
                BuildOUStructure.Wait();
                foreach(ADTree t in tree.ChildOUs)
                {
                    TreeNode node = new TreeNode(t.RootOU.Path);
                    treeView1.Nodes.Add(node);
                    if(t.ChildOUs.Count > 0)
                    {
                        AddChildren(node, t);
                    }
                }
            }
    
            private void AddChildren(TreeNode parent, ADTree tree)
            {
                foreach(ADTree t in tree.ChildOUs)
                {
                    TreeNode node = new TreeNode(t.RootOU.Path);
                    parent.Nodes.Add(node);
                    if(t.ChildOUs.Count > 0)
                    {
                        AddChildren(node, t);
                    }
                }
            }
        }
    
        public class ADTree
        {
            DirectoryEntry rootOU = null;
            string rootDN = string.Empty;
            List<ADTree> childOUs = new List<ADTree>();
    
            public DirectoryEntry RootOU
            {
                get { return rootOU; }
                set { rootOU = value; }
            }
    
            public string RootDN
            {
                get { return rootDN; }
                set { rootDN = value; }
            }
    
            public List<ADTree> ChildOUs
            {
                get { return childOUs; }
                set { childOUs = value; }
            }
    
            public ADTree(string dn)
            {
                RootOU = new DirectoryEntry(dn);
                RootDN = dn;
                BuildADTree().Wait();
            }
    
            public ADTree(DirectoryEntry root)
            {
                RootOU = root;
                RootDN = root.Path;
                BuildADTree().Wait();
            }
    
            private Task BuildADTree()
            {
                return Task.Factory.StartNew(() =>
                {
                    object locker = new object();
                    Parallel.ForEach(RootOU.Children.Cast<DirectoryEntry>().AsEnumerable(), child =>
                    {
                        if (child.SchemaClassName.Equals("organizationalUnit"))
                        {
                            ADTree ChildTree = new ADTree(child);
                            lock (locker)
                            {
                                ChildOUs.Add(ChildTree);
                            }
                        }
                    });
                });
            }
        }
    }
