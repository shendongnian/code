     private void button67_Click(object sender, EventArgs e)
        {
            if (textBox81.Text == "")
            {
                MessageBox.Show("you must choose table name");
            }
            if (textBox81.Text != "")
            {
                connect();
               
                cmd = new OleDbCommand("select  * from  " + textBox81.Text + " ", conn);
                ds = new DataSet();
          
                dp = new OleDbDataAdapter(cmd);
                dp.Fill(ds,""+textBox81.Text+"");
                cm = (CurrencyManager)this.BindingContext[ds];
                textBox79.DataBindings.Add("text",ds,""+textBox81.Text+""+".ProdS_name");
                textBox80.DataBindings.Add("text", ds, "" + textBox81.Text + "" + ".rate");
            }
            
        }
    private void button58_Click(object sender, EventArgs e)
        {
            
                           cm.Position++;
            
            
        }
        private void button59_Click(object sender, EventArgs e)
        {
           
            
                cm.Position= cm.Count - 1; ;
            
        }
        private void button61_Click(object sender, EventArgs e)
        {
            
                            cm.Position=0;
            
        }
