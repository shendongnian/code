        Timer t = new Timer();
        t.Interval = 3000;
        t.Tick += new EventHandler(t_Tick);
        t.Start();
       
        //add then 
        void t_Tick(object sender, EventArgs e)
        {
            if (myListBox.SelectedIndex < myListBox.Items.Count)
                 myListBox.SelectedIndex++;
            else 
                myListBox.SelectedIndex=0;
        } 
