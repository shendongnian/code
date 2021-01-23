    Form2 form2 = new Form2();
     private void button1_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null)
            {
                form1.Visible=false;
                form2.Show();
    
            }
            else MessageBox.Show("Insert Attributes First !");
    
        }
