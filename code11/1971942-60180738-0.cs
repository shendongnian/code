    private void button1_Click(object sender, EventArgs e)
            {
                int m = 0;
                int n = 0;
                bool a = int.TryParse(textBox1.Text, out  m);
                bool b = int.TryParse(textBox3.Text, out n);
                if(a&b==false)
                {
                    MessageBox.Show("please enter number");
                }
                else
                {
                    bool t = IsWithinRange(m,"textbox1", 1, 100);
                    t= IsWithinRange(n, "textbox3", 1, 100);
                }
    
            }
            public bool IsWithinRange(int a, string name,decimal min, decimal max)
            {
                if(a>=min&&a<=max)
                {
                    MessageBox.Show(name + " is between " + min + " and " + max + ".", "Right");
                }
                else
                {
                    MessageBox.Show(name + " must be between " + min + " and " + max + ".", "Entry Error");
                }
                return true;
            }
