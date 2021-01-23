      private void button1_Click_1(object sender, EventArgs e)
        {
                
                timer1.Enabled = true; 
           
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            GetJobsAndStatus();
        }
