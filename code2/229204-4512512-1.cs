         public string TheValue {get;set;}
     
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.TheValue = this.textBox1.Text;
            this.Visible = false;
        }
