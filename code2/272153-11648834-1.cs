             p1= new parent();       
           
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            label1.Text = p1.saySomething("I am parent!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            p1 = new man();
            label1.Text = p1.saySomething("I am man!");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            p1 = new woman();
            label1.Text = p1.saySomething("I am woman!");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            p1 = new child();
            label1.Text = p1.saySomething("I am child!");
        }
