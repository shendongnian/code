    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace treeundoredo
    {
        static class Program
        {
            static TreeNode GetNode(string id, TreeNodeCollection root)
            {
                foreach (TreeNode node in root)
                    if (node.Text == id)
                        return node;
                    else
                    {
                        var subnode = GetNode(id, node.Nodes);
                        if (subnode != null)
                            return subnode;
                    }
    
                return null;
            }
    
            [STAThread]
            static void Main()
            {
                // list of (node, parent)
                List<KeyValuePair<string, string>> undo = new List<KeyValuePair<string, string>>(), redo = new List<KeyValuePair<string, string>>();
    
                Random rng = new Random();
                TreeView Tree = new TreeView() { Size = new Size(200, 250) };
                Tree.Nodes.Add("Root");
                Tree.NodeMouseClick += (s, e) => { undo.Add(new KeyValuePair<string, string>(e.Node.Nodes.Add(rng.Next().ToString()).Text, e.Node.Text)); Tree.ExpandAll(); redo.Clear(); };
    
                Button Undo = new Button() { Text = "Undo", Left = 205 };
                Undo.Click += (s, e) => { if (undo.Count > 0) { var kvp = undo[undo.Count - 1]; GetNode(kvp.Key, Tree.Nodes).Remove(); redo.Add(kvp); undo.Remove(kvp); } };
    
                Button Redo = new Button() { Text = "Redo", Left = 205, Top = 50 };
                Redo.Click += (s, e) => { if (redo.Count > 0) { var kvp = redo[redo.Count - 1]; GetNode(kvp.Value, Tree.Nodes).Nodes.Add(kvp.Key); redo.Remove(kvp); undo.Add(kvp); Tree.ExpandAll(); } };
    
                Form frm = new Form();
                frm.Controls.AddRange(new Control[] { Tree, Undo, Redo });
                Application.Run(frm);
            }
    
        }
    }
