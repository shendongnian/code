     // kombo is now scoped for use throughout this class
     ComboBox kombo = null;
     private void Form1_Load(object sender, EventArgs e)
        {
            Button przycisk = new Button(); 
            przycisk.Name = "przycisk";
            przycisk.Dock = DockStyle.Bottom;
            przycisk.Text = "Wybierz";
            
            // Assign to our kombo instance
            kombo = new ComboBox(); 
            kombo.Name = "kombo";
            kombo.Dock = DockStyle.Bottom;
            kombo.Items.Add("Przycisk");   
            kombo.Items.Add("Etykeita");
            kombo.Items.Add("Pole tekstowe");
            Controls.Add(kombo);  
            Controls.Add(przycisk);
            przycisk.Click += new EventHandler(przycisk_Click); 
            
        }
        private void przycisk_Click(object sender, EventArgs e)
        {
            // Using the kombo we created in form load, which is still referenced
            // in the class
            kombo.Items.Add("Panel");  //just an example 
        }
