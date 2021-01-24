        //The entered values will be stored as List of integars.
        List<int> enteredValues = new List<int>();
        //The button will store each value in the List of integers.
        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            
            if(int.TryParse(textBox1.Text,out value))
            {
                enteredValues.Add(value);
            }
            else
            {
                //Show error message here.
            }
        }
        //This button will calculate the sum of entered values.
        private void button2_Click(object sender, EventArgs e)
        {
            int totalValues = 0;
            foreach(int val in enteredValues)
            {
                totalValues += val;
            }
        }
