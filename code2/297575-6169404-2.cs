    if (e.Node.Parent != null && e.Node.Parent.Text == "Tables")
    {
        this.Controls.Remove(dg);
        if(e.Node.Parent.Parent != null)
        { 
           this.dg= dal.showTable(e.Node.Text,e.Node.Parent.Parent.Text);
           this.dg.Location = new System.Drawing.Point(this.tr.Width + 1, this.menuStrip1.Height + 2);
           this.dg.Size = new System.Drawing.Size(n - dg.Location.X, 300);
           this.dg.BackgroundColor = System.Drawing.Color.White;
           this.tableName = e.Node.Text;    
           this.Controls.Add(dg);
        }
    }
    else if (e.Node.FirstNode != null && e.Node.FirstNode.Text == "Tables")
    {
       dal.changeDatabase(e.Node.Text);
    }
   
