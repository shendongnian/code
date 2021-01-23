    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    
    public static class ExtensionMethods
    {
      public static void ExchangeRootNodes(this TreeView treeView, string key1, string key2)
      {
        treeView.BeginUpdate();
        try {
          int i1 = treeView.Nodes.IndexOfKey(key1);
          if (i1 == -1)
            throw new ArgumentException("No node with this key: " + key1, "key1");
          int i2 = treeView.Nodes.IndexOfKey(key2);
          if (i2 == -1)
            throw new ArgumentException("No node with this key: " + key2, "key2");
          if (i1 == i2)
            return;
          var node1 = treeView.Nodes[i1];
          var node2 = treeView.Nodes[i2];
          node1.Remove();
          node2.Remove();
          if (i1 < i2) {
            treeView.Nodes.Insert(i1, node2);
            treeView.Nodes.Insert(i2, node1);
          } else {
            treeView.Nodes.Insert(i2, node1);
            treeView.Nodes.Insert(i1, node2);
          }
        } finally {
          treeView.EndUpdate();
        }
      }
    } 
    
    public static class Program 
    {
      public static void Main() 
      {
        var form = new Form() { Left = 100, Top = 100, ClientSize = new Size(220, 300), Text = "Node Exchange Test" };
        
        var treeView = new TreeView() { Left = 10, Top = 10, Width = 200, Height = 245 };
        form.Controls.Add(treeView);
        treeView.BeginUpdate();
        try {
          treeView.Nodes.Add("MONITOR", "MONITOR");
          treeView.Nodes[0].Nodes.Add("LG");
          treeView.Nodes[0].Nodes.Add("Samsung");
          treeView.Nodes[0].Nodes.Add("HP");
          treeView.Nodes.Add("KEYBOARD", "KEYBOARD");
          treeView.Nodes[1].Nodes.Add("HP");
          treeView.Nodes[1].Nodes.Add("Dell");
          treeView.Nodes[1].Nodes[1].Nodes.Add("Black");
          treeView.Nodes[1].Nodes[1].Nodes.Add("White");
          treeView.Nodes.Add("MOUSE", "MOUSE");
          treeView.ExpandAll();
        } finally {
          treeView.EndUpdate();
        }
        
        var button = new Button() {Left = 10, Top = 265, Width = 200, Height = 25, Text = "MONITOR <-> KEYBOARD" };
        form.Controls.Add(button);
        button.Click += delegate(object sender, EventArgs e) {
          try {
            treeView.ExchangeRootNodes("MONITOR", "KEYBOARD");
          } catch (ArgumentException exception) {
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        };
        
        form.Visible = true;
        Application.Run(form);
      }
    }
