     void Form1_Load(object sender, EventArgs e)
     {
        var innerPanel = new Panel();
        outerPanel.Controls.Add(innerPanel);
        innerPanel.MouseDown += (a,b) => 
         { 
           outerPanel.Controls.Remove(innerPanel);
           Controls.Add(innerPanel);
           innerPanel.MouseUp += (x,y) => MessageBox.Show("!");
         };
     }
