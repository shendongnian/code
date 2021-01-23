     private void textBox1_KeyPress(object sender, KeyPressEventArgs e)         
     {             
         if (e.Handled = (e.KeyChar == (char)Keys.Space))             
         {                 
            if(((TextBox)sender).Text.Replace(" ","") == "")
            {
                 MessageBox.Show("Spaces are not allowed");  
                 ((TextBox)sender).Text = string.Empty;
            }           
         }          
     } 
