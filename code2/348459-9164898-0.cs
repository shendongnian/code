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
