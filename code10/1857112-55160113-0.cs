    class MyClass
    {
        bool foo;
        private void button1_Click(object sender, EventArgs e)
        {            
            if (this.foo)
            {
                label1.Text = "GOOD";
                this.foo=false;
            }
            else
            {
                label1.Text = "BAD";
                this.foo = true;
            }
        }
    }
    
