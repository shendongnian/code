    Button b;
    foreach (int i in Enumerable.Range(0, 100))
    {
      
            b = new Button();
            //b.Size = new System.Drawing.Size(20, 20); 
            b.Dock = DockStyle.Fill
            b.Click += new EventHandler(anyButton_Click); // <-- all wired to the same handler
            tableLayoutPanel.Controls.Add(b);
        
    }
