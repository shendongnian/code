        ComboBox c1 = new ComboBox();
            ComboBox c2 = new ComboBox();
           
            c1.SelectedIndexChanged += new EventHandler(c1_SelectedIndexChanged);
            c2.SelectedIndexChanged += new EventHandler(c2_SelectedIndexChanged);
        void c2_SelectedIndexChanged(object sender, EventArgs e)
        {
            c1.SelectedIndexChanged -= c1_SelectedIndexChanged;
            c2.SelectedIndex = 2;
            c1.SelectedIndexChanged += c1_SelectedIndexChanged;
        }
        void c1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c2.SelectedIndexChanged -= c2_SelectedIndexChanged;
            c1.SelectedIndex = 2;
            c2.SelectedIndexChanged += c2_SelectedIndexChanged;
        }
 
   
