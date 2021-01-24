    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // assuming tree view has a root node already
    
                treeView1.CheckBoxes = true;
                treeView1.BeginUpdate();
    
                var builder = new StringBuilder();
    
                // read first 100000 paths from a file
                var watch = Stopwatch.StartNew();
                var lines = File.ReadAllLines(@"C:\temp\files.txt").Take(100000).ToArray();
                builder.AppendLine($"Time taken reading paths: {watch.Elapsed}");
    
                // populate tree view with these paths
                watch.Restart();
                foreach (var line in lines)
                {
                    var root = treeView1.TopNode;
                    var keys = line.Split(Path.DirectorySeparatorChar);
    
                    foreach (var key in keys)
                    {
                        var nodes = root.Nodes;
                        root = nodes.ContainsKey(key) ? nodes[key] : nodes.Add(key, key);
                    }
                }
    
                builder.AppendLine($"Time taken populating tree: {watch.Elapsed}");
    
                // add some garbage and shuffle
                watch.Restart();
                var range = Enumerable.Range(0, 1000).ToArray();
                var random = new Random();
                var strings = range.Select(s => lines[random.Next(lines.Length)]);
                var garbage = range.Select(s => s.ToString());
                var array = strings.Concat(garbage).OrderBy(s => random.Next());
                builder.AppendLine($"Time taken randomizing: {watch.Elapsed}");
    
                // now check checkable items
                watch.Restart();
                foreach (var line in array)
                {
                    var root = treeView1.TopNode;
                    var keys = line.Split(Path.DirectorySeparatorChar);
    
                    foreach (var key in keys)
                    {
                        var nodes = root.Nodes;
    
                        root = nodes.ContainsKey(key) ? nodes[key] : null;
    
                        if (root == null)
                            break;
                    }
    
                    if (root == null)
                        continue;
    
                    root.Checked = true;
                }
    
                builder.AppendLine($"Time taken checking items: {watch.Elapsed}");
    
                treeView1.EndUpdate();
    
                MessageBox.Show(builder.ToString());
            }
        }
    }
