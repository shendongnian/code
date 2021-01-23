     public bool TextWasChanged = false;
     protected void form1_load()
     {
         MakeText();
         textBox1.TextChanged += new System.EventHandler(this.textBox_TextChanged);
         textBox2.TextChanged += new System.EventHandler(this.textBox_TextChanged);    
         ...
         ...
         ...
    
     }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextWasChanged = true;
        }
        void UpdateDB()
        {
            if(TextWasChanged)
            {
                  // Update DB
            }
        }
 
