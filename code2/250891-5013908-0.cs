            private void HandleOnSetButtonClick(object sender, EventArgs e)
            {
                this.IsSetClicked = true;
                this.Close();
    
                //or 
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }   
            public Boolean IsSetClicked
            {
               get;
               private set;
            }
