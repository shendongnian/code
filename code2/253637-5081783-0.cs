        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.txt1.Text = "foo";
    
        }
        protected void txt1_TextChanged(object sender, EventArgs e)
        {
            txt2.Text = txt1.Text;
        }
