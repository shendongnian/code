     private void button1_Click(object sender, EventArgs e)
            {
                string whatsTheValue="";
                Form2 frm = new Form2();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    whatsTheValue = frm.TheValue;
    
                MessageBox.Show(whatsTheValue);
    
            }
