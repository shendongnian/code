        tasks.Add(Task.Run(() => 
        {
           CustNode c = new CustNode();
           c.Name = d.Name;
           c.Text = d.Name;
           c.SelectedImageIndex = 3;
           c.ImageIndex = 3;
           c.NodeType = "Drive";
           Tview.TopNode.Nodes.Add(c);
           Tview.HideCheckBox(c);
           AddNodeToTree(c, c.Name, TreeViewDepth);
         });
