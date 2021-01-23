    private void button1_Click(object sender, EventArgs e)
    {
        string age = textBox1.Text;
        int i = 0; // check if it is a int
        bool result = int.TryParse(age, out i) // see if it is a int
        if(result == true){ // check if it is a int
            string afe;
            string afwe2;
            afe = "You are ";
            afwe2 = " years old!";
            MessageBox.Show(afe + age + afwe2);
        } else {
            MessageBox.Show("Please Enter a Number!"); // error message
        }
    }
