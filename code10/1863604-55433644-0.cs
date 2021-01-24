        MovieForm movieform = null; 
        private void button1_Click(object sender, EventArgs e)
        {
                value = txtSendNum.Text; 
                if(movieform == null)
                {
                       movieform = new MovieForm(); //create an object for MovieForm
                       movieform.Show(); 
                       movieform.ConnectForms(value);            
                }
                else 
                {
                       movieform.ConnectForms(value); 
                       movieform.Focus();  
                 }
        }
 
